using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageStartButton : MonoBehaviour
{

    private int stageNum;
    public int StageNum
    {
        get
        {
            return stageNum;
        }
        set
        {
            stageNum = value;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(StartGame);
    }
    

    // Update is called once per frame
    public void StartGame()
    {
        Debug.Log("게임 시작" + stageNum);
        string scene = "S" + stageNum;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
