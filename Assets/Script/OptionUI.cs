using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    public Text OptionTitle;
    public Text BGMbuttonText;
    public Text FollowCamButtonText;
    public Text OverlapButtonText;
    public GameObject MenuObject;
    public GameObject optionPanel;
    public GameObject ballOverlapUI;
    // Start is called before the first frame update
    void Start()
    {
        OptionTitle.text = LanguageMgr.Instance.GetWord(LanguageMgr.Lcode.Setting);

        optionPanel.SetActive(false);
        if (!GameObject.Find("BGM").GetComponent<AudioSource>().isPlaying)
            BGMbuttonText.text = "BGM OFF";
        else
            BGMbuttonText.text = "BGM ON";

        if (PlayerPrefs.GetInt("FollowCam") == 1)//1 = true
        {
            FollowCamButtonText.text = "Follow Cam ON";
        }
        else
        {
            FollowCamButtonText.text = "Follow Cam OFF";
        }

        if (PlayerPrefs.GetInt("BallOverLap") == 1)//1 = true
        {
            OverlapButtonText.text = "BallOverLap ON";
            ballOverlapUI.SetActive(true);
        }
        else
        {
            OverlapButtonText.text = "BallOverLap OFF";
            ballOverlapUI.SetActive(false);
        }

    }
    public void OnEnable()
    {
        Debug.Log("OptionON");
    }
    public void FollowCamButton()
    {
        if (PlayerPrefs.GetInt("FollowCam") == 1)//1 = true
        {
            FollowCamButtonText.text = "Follow Cam OFF";
            PlayerPrefs.SetInt("FollowCam", 0);
            GameObject.Find("CameraSpot").GetComponent<CameraCtrl>().followCam = false;
        }
        else
        {
            FollowCamButtonText.text = "Follow Cam ON";
            PlayerPrefs.SetInt("FollowCam", 1);
            GameObject.Find("CameraSpot").GetComponent<CameraCtrl>().followCam = true;
        }
        PlayerPrefs.Save();
        
    }

    public void OverlapButton()
    {
        if (PlayerPrefs.GetInt("BallOverLap") == 1)//1 = true
        {
            OverlapButtonText.text = "BallOverLap OFF";
            PlayerPrefs.SetInt("BallOverLap", 0);
            ballOverlapUI.SetActive(false);
            
        }
        else
        {
            OverlapButtonText.text = "BallOverLap ON";
            PlayerPrefs.SetInt("BallOverLap", 1);
            ballOverlapUI.SetActive(true);
            
        }
        PlayerPrefs.Save();

    }

    public void BGMButton()
    {
        if (GameObject.Find("BGM").GetComponent<AudioSource>().isPlaying)
        {
            BGMbuttonText.text = "BGM OFF";
            GameObject.Find("BGM").GetComponent<AudioSource>().Pause();
        }
        else
        {
            BGMbuttonText.text = "BGM ON";
            GameObject.Find("BGM").GetComponent<AudioSource>().Play();
        }

    }
    public void BackToMenuButton()
    {
        optionPanel.SetActive(false);
        MenuObject.SetActive(true);


    }
    // Update is called once per frame
    void Update()
    {
        if (optionPanel.active && Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMenuButton();
            
        }
            
    }
}
