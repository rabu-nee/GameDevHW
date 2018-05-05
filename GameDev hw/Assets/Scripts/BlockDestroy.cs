using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour {

    public bool destroyMode;

    private void Awake()
    {
        destroyMode = GameObject.FindGameObjectWithTag("Slingshot").GetComponent<Slingshot>().destroyMode;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (destroyMode)
        {
            if (collision.gameObject.CompareTag("Block"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
