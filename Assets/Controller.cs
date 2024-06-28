using System.Collections;
using System.Collections.Generic;
using Gley.MobileAds;
using UnityEngine;

public class Controller : MonoBehaviour
{
    UniWebView webView;

    [SerializeField]
    GameObject HomePage;
    public RectTransform myUITransform;


    /// <summary>
    /// Initialize the ads
    /// </summary>
    void Awake()
    {
        var webViewGameObject = new GameObject("UniWebView");
        webView = webViewGameObject.AddComponent<UniWebView>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
        webView.gameObject.SetActive(true);
        webView.ReferenceRectTransform = myUITransform;
        //webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
        var url = UniWebViewHelper.StreamingAssetURLForPath("local_www/index.html");
        webView.Load(url);
        webView.Show();
    }

    private void OnEnable()
    {
        webView.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        webView.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Reload()
    {
        gameObject.SetActive(false);
        webView.gameObject.SetActive(false);
        HomePage.SetActive(true);
    }

    public void GoBack()
    {
        webView.GoBack();
    }

    public void GoForward()
    {
        webView.GoForward();
    }
    // In a UIBehavior script:
    // This method is called whenever the associated `rectTransform` is changed.
    void OnRectTransformDimensionsChange()
    {
        // Update web view's frame to match the reference rect transform.
       // webView.UpdateFrame();
    }
}
