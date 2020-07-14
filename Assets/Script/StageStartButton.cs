using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageStartButton : MonoBehaviour
{
    public Sprite star;
    public Image star1;
    public Image star2;
    public Image star3;

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
    public void SetStar(int score)
    {
        if (score >= 1)
            star1.sprite = star;
        if (score >= 2)
            star2.sprite = star;
        if (score >= 3)
            star3.sprite = star;
    }

}
