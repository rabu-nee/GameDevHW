using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    public static bool created;

    public void Awake()
    {
        if (!created)
        {
            created = true;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
