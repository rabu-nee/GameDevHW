using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    private bool destMode;

    private void Awake()
    {
        destMode = Slingshot.destroyMode;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (destMode)
        {
            if (collision.gameObject.CompareTag("Block"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}