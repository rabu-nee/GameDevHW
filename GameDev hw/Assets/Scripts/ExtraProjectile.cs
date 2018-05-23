using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraProjectile : MonoBehaviour {

    public AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            GameObject.FindGameObjectWithTag("Slingshot").GetComponent<Slingshot>().projectileLeft += 3;
            source.Play();

            MeshRenderer[] mr = this.gameObject.GetComponentsInChildren<MeshRenderer>();
            CapsuleCollider[] col = this.gameObject.GetComponentsInChildren<CapsuleCollider>();

            foreach (MeshRenderer m in mr)
            {
                m.enabled = false;
            }
            foreach(CapsuleCollider c in col)
            {
                c.enabled = false;
            }

            Destroy(this.gameObject, 1);
        }
    }
}
