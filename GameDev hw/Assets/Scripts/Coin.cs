using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    private AudioSource[] source;
    private AudioSource coinS, hitS;
    private Score score;


    private void Awake()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        source = GetComponents<AudioSource>();
        coinS = source[0];
        hitS = source[1];
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            score.score++;
            score.coinsLeft--;
            coinS.Play();
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            Destroy(this.gameObject, 1);
        }
        else if (collision.gameObject.CompareTag("Block"))
        {
            score.coinsLeft--;
            hitS.Play();
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            Destroy(this.gameObject, 1);

        }
    }
}
