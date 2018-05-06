using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelFinish : MonoBehaviour {

    public static GameObject panel;
    public static GameObject[] stars;

    public Text currentLevelText;

	// Use this for initialization
	void Awake () {
        panel = this.gameObject;

        currentLevelText = GameObject.FindGameObjectWithTag("CurrentLevelText").GetComponent<Text>();
        currentLevelText.text = SceneManager.GetActiveScene().name;

        stars = GameObject.FindGameObjectsWithTag("Star");

        foreach(GameObject star in stars)
        {
            star.SetActive(false);
        }
        panel.SetActive(false);
    }

    public void RetryButton()
    {
        panel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
