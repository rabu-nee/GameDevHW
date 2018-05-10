using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    public GameObject[] stars;

    public Text currentLevelText;


    private void Awake()
    {
        stars = GameObject.FindGameObjectsWithTag("Star");
        currentLevelText = GameObject.FindGameObjectWithTag("CurrentLevelText").GetComponent<Text>();
    }

    private void Update()
    {
        currentLevelText.text = "Level " + LevelManager.selectedLevelIndex;
        ShowStars(LevelManager.selectedLevelIndex);
    }

    public void LoadSelectedLevel()
    {
        SceneManager.LoadScene("Level " + LevelManager.selectedLevelIndex);
    }

    public void SelectNextLevel()
    {
        if (LevelManager.selectedLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            LevelManager.selectedLevelIndex++;
        }
        if (LevelManager.selectedLevelIndex == SceneManager.sceneCountInBuildSettings)
        {
            LevelManager.selectedLevelIndex = 1;
        }
    }

    public void SelectPreviousLevel()
    {
        if (LevelManager.selectedLevelIndex == 1)
        {
            LevelManager.selectedLevelIndex = SceneManager.sceneCountInBuildSettings;
        }
        if (LevelManager.selectedLevelIndex <= SceneManager.sceneCountInBuildSettings)
        {
            LevelManager.selectedLevelIndex--;
        }
    }

    private void ShowStars(int sel)
    {
        switch (LevelManager.starsInLevel[sel])
        {
            case 0:
                foreach (GameObject star in stars)
                {
                    star.SetActive(false);
                }
                break;

            case 1:
                stars[0].SetActive(true);
                stars[1].SetActive(false);
                stars[2].SetActive(false);
                break;

            case 2:
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                stars[2].SetActive(false);
                break;

            case 3:
                foreach (GameObject star in stars)
                {
                    star.SetActive(true);
                }
                break;
        }
    }
}
