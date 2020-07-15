using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Text MenuTitleText;
    public GameObject pannel;
    public GameObject optionPannel;
    public Text subTitle;

    public Text BGMbuttonText;
    // Start is called before the first frame update
    void Start()
    {
        MenuTitleText.text = LanguageMgr.Instance.GetWord(LanguageMgr.Lcode.Menu);
        int stageNum=int.Parse(SceneManager.GetActiveScene().name.Substring(1));

        optionPannel.SetActive(false);
        subTitle.text = (stageNum/20+1) +"-"+(stageNum%20+1);
        //subTitle.fontSize = 60 / 720 * Screen.height;
        pannel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            MenuButton();
    }

    public void MenuButton() {
        if (pannel.active || optionPannel.active) {
            Time.timeScale = 1.0f;
            pannel.SetActive(false);
            optionPannel.SetActive(false);
            
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

    public void OptionButton()
    {
        optionPannel.SetActive(true);
        pannel.SetActive(false);
    }
  

}
