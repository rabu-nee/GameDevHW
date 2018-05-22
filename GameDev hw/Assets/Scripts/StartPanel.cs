using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    public GameObject[] stars;

    public Text currentLevelText;
    public int selectedLevelIndex;


    private void Awake()
    {
        stars = GameObject.FindGameObjectsWithTag("Star");
        currentLevelText = GameObject.FindGameObjectWithTag("CurrentLevelText").GetComponent<Text>();
        selectedLevelIndex = 1;
    }

    private void Update()
    {
        currentLevelText.text = "Level " + selectedLevelIndex;
        ShowStars(selectedLevelIndex);
    }

    public void LoadSelectedLevel()
    {
        SceneManager.LoadScene("Level " + selectedLevelIndex);
    }

    public void SelectNextLevel()
    {
        if (selectedLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            selectedLevelIndex++;
        }
        if (selectedLevelIndex == SceneManager.sceneCountInBuildSettings)
        {
            selectedLevelIndex = 1;
        }
    }

    public void SelectPreviousLevel()
    {
        if (selectedLevelIndex == 1)
        {
            selectedLevelIndex = SceneManager.sceneCountInBuildSettings;
        }
        if (selectedLevelIndex <= SceneManager.sceneCountInBuildSettings)
        {
            selectedLevelIndex--;
        }
    }

    private void ShowStars(int sel)
    {
        switch (PlayerPrefs.GetInt("Level " + selectedLevelIndex))
        {
            case 0:
                foreach (GameObject star in stars)
                {
                    star.SetActive(false);
                    Debug.Log("0 stars");
                }
                break;

            case 1:
                stars[0].SetActive(true);
                stars[1].SetActive(false);
                stars[2].SetActive(false);
                Debug.Log("1 stars");
                break;

            case 2:
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                stars[2].SetActive(false);
                Debug.Log("2 stars");
                break;

            case 3:
                foreach (GameObject star in stars)
                {
                    star.SetActive(true);
                }
                Debug.Log("3 stars");
                break;
        }
    }

    public void deletePrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
