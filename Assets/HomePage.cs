using System;
using System.Collections;
using System.Collections.Generic;
using Gley.MobileAds;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomePage : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;
    bool isIn = true;
    int tag = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        API.Initialize();

    }
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if (isIn)
        { 
            if(API.IsInitialized())
            {
                API.ShowBanner(BannerPosition.Bottom, BannerType.Adaptive);
                isIn = false;
            }
        }
    }

    public void LoadWebviewPage()
    {
        tag = 1;
       if(API.IsInterstitialAvailable() )
        {
            ShowInterstitial();
        }
       else
        {
            MyFunction();
        }
    }


    public void ShowInterstitial()
    {
            API.ShowInterstitial(MyFunction);
    }

    public void MyFunction()
    {
        switch (tag)
        {
            case 1:
                {
                    gameObject.SetActive(false);
                    canvas.SetActive(true);
                    canvas.GetComponent<Controller>().enabled = true;
                    Debug.Log("Loading Webview");
                    break;
                }
                
            case 2:
                {
                    Debug.Log("Play Game");
                    SceneManager.LoadScene("QuizGame");
                    break;
                }

            case 3:
                {
                    Debug.Log("Perfect Jump Game");
                    SceneManager.LoadScene("Game");
                    break;
                }

        }
        
    }


    public void PlayGamePage()
    {
        tag = 2;
        if(API.IsInterstitialAvailable())
        {
            ShowInterstitial();
        }
        else
        {
            MyFunction();
        }
    }

    public void PerfectPlayGamePage()
    {
        tag = 3;
        if (API.IsInterstitialAvailable())
        {
            ShowInterstitial();
        }
        else
        {
            MyFunction();
        }
    }
}
