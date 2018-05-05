using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileText : MonoBehaviour {

    private Text projectileText;
    private Slingshot sling;
    private int initLimit;

    private void Awake()
    {
        projectileText = GameObject.FindGameObjectWithTag("ProjectileText").GetComponent<Text>();
        sling = GameObject.FindGameObjectWithTag("Slingshot").GetComponent<Slingshot>();
        initLimit = sling.projectileLimit;        
    }

    private void Update()
    {
        projectileText.text = sling.projectileLimit + " of " + initLimit + " left";
    }
}
