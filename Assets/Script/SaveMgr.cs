using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SaveMgr : MonoBehaviour
{
    public const int MAXSTAGE = 19;

    // Start is called before the first frame update
    private static SaveMgr instance = null;
    public static SaveMgr Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new SaveMgr();
                
            }
            return instance;
        }
    }
    private void Start()
    {
        
    }
    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        
       
    }

    public int GetStage()
    {
        return PlayerPrefs.GetInt("Stage");
    }
    public int GetScore(int stateNum)
    {
        string stageName = "S" + stateNum.ToString();
        return PlayerPrefs.GetInt(stageName);
    }

    public void SetScore(int stageNum, int score)
    {
        int tempScore = GetScore(stageNum);
        string stageName = "S" + stageNum.ToString();        
        PlayerPrefs.SetInt(stageName, Mathf.Max(tempScore, score));
        int stage = GetStage();
        if (score>0&&stage == stageNum && stage<MAXSTAGE)
        {
            stage++;
            PlayerPrefs.SetInt("Stage", stage);
        }
        //Debug.Log(stageNum+"Game is save");
        PlayerPrefs.Save();
    }
 }
