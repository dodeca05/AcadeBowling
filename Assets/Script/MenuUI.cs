using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public GameObject pannel;
    public Text subTitle;

    public Text BGMbuttonText;
    // Start is called before the first frame update
    void Start()
    {
        int stageNum=int.Parse(SceneManager.GetActiveScene().name.Substring(1))+1;
        
        subTitle.text = "["+ Application.systemLanguage+"]스테이지 " + stageNum;
        pannel.SetActive(false);
        if (!GameObject.Find("BGM").GetComponent<AudioSource>().isPlaying)
            BGMbuttonText.text = "BGM OFF";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            MenuButton();
    }

    public void MenuButton() {
        if (pannel.active) {
            Time.timeScale = 1.0f;
            pannel.SetActive(false);
            
        }
        else
        {
            Time.timeScale = 0.0f;
            pannel.SetActive(true);
        }
    }

    public void BGMButton() {
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
    public void BackToLobby() {

        
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }
  

}
