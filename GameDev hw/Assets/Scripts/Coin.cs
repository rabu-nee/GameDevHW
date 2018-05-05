using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    private AudioSource[] source;
    private AudioSource coinS, hitS;


    private void Awake()
    {
        source = GetComponents<AudioSource>();
        coinS = source[0];
        hitS = source[1];
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Slingshot.score++;
            coinS.Play();
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            Destroy(this.gameObject, 1);
        }
        else if (collision.gameObject.CompareTag("Block"))
        {
            hitS.Play();
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            Destroy(this.gameObject, 1);

        }
    }
}
