///ca-app-pub-8179797674906935~6624229151
using System.Collections;
using UnityEngine;
using System;
using System.IO;

public class CameraZoom : Singleton<CameraZoom>
{
    
    [SerializeField]
    SpriteRenderer backgroundImage;

    [SerializeField]
    Camera cam;

    private void Start()
    {
        SetCameraOrthographicSize();
    }


    private void SetCameraOrthographicSize()
    {
        // Setting camera orthographic size accroding to the background image of
        //Game.If you want to calculate width and height use the below commented
        //code and comment below line

        Debug.Log("Chetu betu");
        Camera.main.orthographicSize = backgroundImage.bounds.size.y / 2;
        // this code will calculate camera orthograhpic size using width and height ratio
        // uncomment this block of code
    }

}



