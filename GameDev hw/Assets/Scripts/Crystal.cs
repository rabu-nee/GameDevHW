using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour {

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            GameObject.FindGameObjectWithTag("Slingshot").GetComponent<Slingshot>().destroyMode = true;

            Destroy(this.gameObject);
        }
    }
}
