using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

	// Fields set in the Unity Inspector pane
	public GameObject prefabProjectile;
	public float velocityMult = 4f;
	
	// Fields set dynamically
	private GameObject launchPoint;
	private Vector3 launchPos;
	public GameObject projectile;
    private AudioSource source;

    public LineRenderer TrajectoryLine;

	public static bool aimingMode;

    public static bool destroyMode;

    public GameObject particle;

    public int projectileLeft;

    void Awake(){
		//print ("Awake()");
		Transform launchPointTrans = transform.Find("LaunchPoint");
		launchPoint = launchPointTrans.gameObject;
		launchPoint.SetActive(false);
		launchPos = launchPointTrans.position;
        source = GetComponent<AudioSource>();
        destroyMode = false;

    }
	
	void OnMouseEnter() {
		//print ("Enter");
		launchPoint.SetActive(true);
	}
	
	void OnMouseExit() {
		//print ("Exit");
		if(!aimingMode) 
			launchPoint.SetActive(false);
	}
	
	void OnMouseDown(){
		if(projectileLeft != 0)
        {

            // Player pressed mouse while over Slingshot
            aimingMode = true;

            // Instantiate a projectile
            projectile = Instantiate(prefabProjectile) as GameObject;

            // Start it at launch position
            projectile.transform.position = launchPos;

            // Set it to kinematic for now
            projectile.GetComponent<Rigidbody>().isKinematic = true;

            particle = projectile.transform.GetChild(0).gameObject;
            particle.SetActive(false);

            if (destroyMode)
            {
                PhysicMaterial pMat = projectile.GetComponent<SphereCollider>().material;
                pMat.bounciness = 0;
                pMat.staticFriction = 0;
                pMat.dynamicFriction = 0;
                pMat.bounceCombine = PhysicMaterialCombine.Minimum;
                //pMat.frictionCombine = PhysicMaterialCombine.Minimum;
                Material mat = projectile.GetComponent<MeshRenderer>().material;
                mat.SetColor("_OutlineColor", Color.magenta);
                particle.SetActive(true);
            }
        }
	}

	void Update() {
		// If the Slingshot is not in aiming mode, don't run this code
		if(!aimingMode) return;

		// Get the current mouse position in 2D screen coordinates
		Vector3 mousePos = Input.mousePosition;
		// Convert the mouse position to 3D world coordinates
		mousePos.z = - Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos);

		// Find the delta from launch position to 3D mouse position
		Vector3 mouseDelta = mousePos3D - launchPos;

		// Limit mouseDelta to the radius of the Slingshot SphereCollider
		float maxMagnitude = GetComponent<SphereCollider>().radius;
		mouseDelta = Vector3.ClampMagnitude(mouseDelta, maxMagnitude);

		// Now move the projectile to this new position
		projectile.transform.position = launchPos + mouseDelta;

        DisplayTrajectoryLine();

        if (Input.GetMouseButtonUp(0))
        {
            // The mouse has been released
            aimingMode = false;

            //play sound
            source.Play();

            // Fire off the projectile with given velocity
            projectile.GetComponent<Rigidbody>().isKinematic = false;
            projectile.GetComponent<Rigidbody>().velocity = -mouseDelta * velocityMult;

            // Set the Followcam's target to our projectile
            FollowCam.S.poi = projectile;

            TrajectoryLine.enabled = false;
            projectile = null;

            projectileLeft--;
            destroyMode = false;
        }
    }

    private void DisplayTrajectoryLine()
    {
        TrajectoryLine.enabled = true;
        Vector3 v2 = launchPos - projectile.transform.position;
        int segCount = 15;
        float segScale = 2;
        Vector3[] segments = new Vector3[segCount];

        segments[0] = projectile.transform.position;

        Vector3 segVel = new Vector3(v2.x, v2.y, 0) * velocityMult ;

        float angle = Vector3.Angle(segVel, new Vector2(1, 0));
        float time = segScale / segVel.magnitude;

        for (int i = 1; i < segCount; i++)
        {
            float time2 = i * Time.fixedDeltaTime * 5;
            segments[i] = segments[0] + segVel * time2 + 0.5f * Physics.gravity * Mathf.Pow(time2, 2);
        }

        TrajectoryLine.positionCount = segCount;
        for(int i = 0; i < segCount; i++)
        {
            TrajectoryLine.SetPosition(i, segments[i]);
        }
    }

    public void backToSling()
    {
        FollowCam.S.poi = this.gameObject;
    }
}
