using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ADMgr : MonoBehaviour
{
    // Start is called before the first frame update


    private const string gameId = "3715239";
    private const bool testMode = true;
    private bool showBanner = true;
    private int count = 0;


    private static ADMgr instance;
    public static ADMgr Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenInitialized());


    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("AD init is finished!!");
        if(showBanner)
            BannerShow();


    }

    public void AddCount(int score=1)
    {
        count+=score;
        Debug.Log("AD Score "+count+" "+score);
        if (count >= 15)
        {
            count = 0;
            //스테이지 5번마다 광고
            if (Advertisement.isInitialized)
                Advertisement.Show();
            else
                Debug.Log("AD FAIL");
        
        }
    
    
    }

    public void BannerHide()
    {

        if (Advertisement.isInitialized && showBanner==true)
        {
            
            Advertisement.Banner.Hide();
        }
        showBanner = false;
    }

    public void BannerShow()
    {

        if (Advertisement.isInitialized && showBanner == false)
        {
            
            string placementId = "bannerPlacement";
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(placementId);
        }
        showBanner = true;
    }






}
