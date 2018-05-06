using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private Text scoreText;
    private GameObject[] coins;
    public int maxCoinNum;
    public int coinsLeft;
    public int score;

    private void Awake()
    {
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        coins = GameObject.FindGameObjectsWithTag("Coin");
        maxCoinNum = coins.Length;
        coinsLeft = maxCoinNum;
    }

    private void Update()
    {
        scoreText.text = "score: " + score + " / " + maxCoinNum;
    }
}
