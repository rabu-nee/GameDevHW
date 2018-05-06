using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour {

    public AudioSource[] source;

	// Use this for initialization
	void Awake () {
        source = GetComponents<AudioSource>();
	}

    private void OnParticleCollision(GameObject collision)
    {
            int ran = Random.Range(0, 3);
            source[ran].volume = 0.5f;
            source[ran].Play();
        
    }
}
