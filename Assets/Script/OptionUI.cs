using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{

    public Text BGMbuttonText;
    public Text FollowCamButton;
    // Start is called before the first frame update
    void Start()
    {
        if (!GameObject.Find("BGM").GetComponent<AudioSource>().isPlaying)
            BGMbuttonText.text = "BGM OFF";
        else
            BGMbuttonText.text = "BGM ON";
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
