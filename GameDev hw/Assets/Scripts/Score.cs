using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private Text scoreText;
    private GameObject[] coins; 

    private void Awake()
    {
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        coins = GameObject.FindGameObjectsWithTag("Coin");
    }

    private void Update()
    {
        scoreText.text = "score: " + Slingshot.score + " / " + coins.Length;
    }
}
