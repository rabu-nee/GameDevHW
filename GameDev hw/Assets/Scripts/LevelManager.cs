using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static int[] starsInLevel;
    public static int selectedLevelIndex;
    private static bool created;

    private void Awake()
    {
        if(!created)
        {
            created = true;
            DontDestroyOnLoad(this.gameObject);
        }
        starsInLevel = new int[SceneManager.sceneCountInBuildSettings];
        starsInLevel[0] = 0;
        selectedLevelIndex = 1;
    }
}
