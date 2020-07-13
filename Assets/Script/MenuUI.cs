using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public GameObject pannel;
    public GameObject optionPannel;
    public Text subTitle;

    public Text BGMbuttonText;
    // Start is called before the first frame update
    void Start()
    {
        int stageNum=int.Parse(SceneManager.GetActiveScene().name.Substring(1))+1;

        optionPannel.SetActive(false);
        subTitle.text = "["+ Application.systemLanguage+"]스테이지 " + stageNum+" "+Screen.width+" * "+Screen.height;
        subTitle.fontSize = 15 / 720 * Screen.height;
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

    public void OptionButton()
    {
        optionPannel.SetActive(true);
        gameObject.SetActive(false);
    }
  

}
