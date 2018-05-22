using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseCheck : MonoBehaviour {

    private Slingshot sling;
    private Score score;

    private GameObject mUI;

    private void Awake()
    {
        sling = GameObject.FindGameObjectWithTag("Slingshot").GetComponent<Slingshot>();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();

        mUI = GameObject.FindGameObjectWithTag("MainUI");
    }

    // Update is called once per frame
    void Update () {
        EndGame();
	}

    private void EndGame()
    {
        if((score.score == score.maxCoinNum) || (sling.projectileLeft == 0) || (score.coinsLeft == 0))
        {
            mUI.SetActive(false);
            LevelFinish.panel.SetActive(true);
            showStars();
        }
    }

    private void showStars()
    {
        //80% of coins collected = 3 stars
        if(score.score >= (score.maxCoinNum * 0.80))
        {

            foreach (GameObject star in LevelFinish.stars)
            {
                star.SetActive(true);
            }
            if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name) < 3)
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 3);
            }

            /*
            if (LevelManager.starsInLevel[LevelManager.selectedLevelIndex] < 3)
            {
                LevelManager.starsInLevel[LevelManager.selectedLevelIndex] = 3;
            }
            */
        }

        //50% of coins collected = 2 stars
        if (score.score >= (score.maxCoinNum * 0.50))
        {
            LevelFinish.stars[0].SetActive(true);
            LevelFinish.stars[1].SetActive(true);

            if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name) < 2)
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 2);
            }

            /*
             * if (LevelManager.starsInLevel[LevelManager.selectedLevelIndex] < 2)
            {
                LevelManager.starsInLevel[LevelManager.selectedLevelIndex] = 2;
            }
            */
        }

        //25% of coins collected = 1 stars
        if (score.score >= (score.maxCoinNum * 0.25))
        {
            LevelFinish.stars[0].SetActive(true);

            if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name) < 1)
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
            }

            /*
            if (LevelManager.starsInLevel[LevelManager.selectedLevelIndex] < 1)
            {
                LevelManager.starsInLevel[LevelManager.selectedLevelIndex] = 1;
            }
            */
        }
    }
}
