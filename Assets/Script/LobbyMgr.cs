using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyMgr : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject buttonPrefab;
    public GameObject uiCanvas;

    private int page = 0;

    private int stage;
    void Start()
    {
        SetLobby();
    }

    public void SetLobby()
    {
        stage = SaveMgr.Instance.GetStage();
        Vector3 pos = buttonPrefab.transform.localPosition;
        //Debug.Log(pos);

        int ScH = Screen.height;
        int ScW = Screen.width;
        for (int i = 25 * page; i <= Mathf.Min(stage, 25 * (page + 1)); i++)
        {
            int row = i % 5 - 2;
            int col = i / 5 - 2;
            int temp = Mathf.Min(ScH, ScW) / 5;
            GameObject tempButton = Instantiate(buttonPrefab);
            tempButton.transform.SetParent(uiCanvas.transform);
            tempButton.GetComponent<StageStartButton>().StageNum = i;
            Vector3 localPos = new Vector3(row * temp, -col * temp);
            tempButton.transform.localPosition = localPos;
            Text tempText = tempButton.GetComponentInChildren<Text>();
            string btnText = (i + 1) + "\n";
            for (int j = 0; j < SaveMgr.Instance.GetScore(i); j++)
                btnText += "★";
            tempText.text = btnText;


        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
    public void StartStage(int stageNum)
    {
        Debug.Log("게임 스타트" + stageNum.ToString());

        
    }
}
