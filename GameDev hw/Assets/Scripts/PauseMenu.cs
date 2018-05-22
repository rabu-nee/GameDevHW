using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public void LevelSelectionButton()
    {
        SceneManager.LoadScene("Start");
        Time.timeScale = 1.0f;
    }

    public void QuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ContinueButton()
    {
        Time.timeScale = 1.0f;
    }

    public void PauseMenuButton()
    {
        Time.timeScale = 0.0f;
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }
}
