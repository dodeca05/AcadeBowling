using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultUI : MonoBehaviour
{
    public Text title;
    public List<GameObject> menubtn;
    public GameObject nextBtn;
    private int score;
    private int maxScore;

    
    public void SetResult(int score,int maxScore=3)
    {
        this.score = score;
        this.maxScore = maxScore;

        string sceneName = SceneManager.GetActiveScene().name;
        int stageNum = int.Parse(sceneName.Substring(1));
        SaveMgr.Instance.SetScore(stageNum, score);
        if (stageNum < SaveMgr.Instance.GetStage())
            nextBtn.SetActive(true);
        else
            nextBtn.SetActive(false);

        
        DrawUI();
    }
    void OnEnable()
    {
        DrawUI();
        for (int i = 0; i < menubtn.Count; i++)
            menubtn[i].SetActive(false);
        //Debug.Log("Display result" + score);

    }

    private void OnDisable()
    {
        for (int i = 0; i < menubtn.Count; i++)
            menubtn[i].SetActive(true);
    }
    void DrawUI()
    {
        if (score == 0) title.text = "실패";
        else
        {
            title.text = "클리어\n";

            for (int i = 0; i < maxScore; i++)
            {
                if (i < score)
                    title.text += "★";
                else
                    title.text += "☆";
            }
        }
    }
    public void NextStage() {
        string scene ="S"+(int.Parse(SceneManager.GetActiveScene().name.Substring(1))+1);
        //Load it
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
    public void Restart()
    {
    

        //Get current scene name
        string scene = SceneManager.GetActiveScene().name;
        //Load it
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

}
