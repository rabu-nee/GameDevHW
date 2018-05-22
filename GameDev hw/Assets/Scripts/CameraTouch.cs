using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTouch : MonoBehaviour
{
    private Vector3 ResetCamera;
    private Vector3 Origin;
    private Vector3 Difference;
    public static bool Drag = false;
    void Start()
    {
        ResetCamera = Camera.main.transform.position;
    }
    void LateUpdate()
    {
        if(!Slingshot.aimingMode)
        {
            if (Input.GetMouseButton(0))
            {
                Difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
                if (Drag == false)
                {
                    Drag = true;
                    Origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    FollowCam.S.poi = null;
                }
            }
            else
            {
                Drag = false;
            }

            if (Drag == true)
            {
                Camera.main.transform.position = Origin - Difference;
            }

            //RESET CAMERA TO STARTING POSITION WITH RIGHT CLICK
            if (Input.GetMouseButton(1))
            {
                Camera.main.transform.position = ResetCamera;
            }
        }
    }
}