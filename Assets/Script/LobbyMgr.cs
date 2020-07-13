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

    private List<GameObject> btnLst;
    private List<Vector3> aniTargetPosLst;
    private int page = 0;
    private int maxPage = 0;
    private int stage;
    private int screenHeight;
    private int screenWidth;
    private float animate = 0.0f;
    void Start()
    {

        screenHeight = Screen.height;
        screenWidth = Screen.width;

        maxPage = Mathf.Max((SaveMgr.Instance.GetStage()-1) / 25,0);
        Debug.Log("MaxPage=" + maxPage);
        btnLst = new List<GameObject>();
        aniTargetPosLst = new List<Vector3>();

        SetLobby();
        
    }

    public void SetLobby()
    {
        stage = SaveMgr.Instance.GetStage();
        Vector3 pos = buttonPrefab.transform.localPosition;
        //Debug.Log(pos);
        
        int ScH = screenHeight;
        int ScW = screenWidth;
        for (int i = 25 * page; i <= Mathf.Min(stage, 25 * (page+1)-1); i++)
        {
            int row = (i%25) % 5 - 2;
            int col = (i%25) / 5 - 2;
            int temp = Mathf.Min(ScH, ScW) / 5;
            GameObject tempButton = Instantiate(buttonPrefab);
            btnLst.Add(tempButton);
            tempButton.transform.SetParent(uiCanvas.transform);
            tempButton.GetComponent<StageStartButton>().StageNum = i;
            Vector3 localPos = new Vector3(row * temp, -col * temp);
            tempButton.transform.localPosition = localPos;
            aniTargetPosLst.Add(localPos);
            Text tempText = tempButton.GetComponentInChildren<Text>();
            string btnText = (i + 1) + "\n";
            for (int j = 0; j < SaveMgr.Instance.GetScore(i); j++)
                btnText += "★";
            tempText.text = btnText;


        }
        
        
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        if (animate != 0.0f)
        {
            
            if (animate < 0)
            {
                animate += Time.deltaTime;
                if (animate > 0)
                    animate = 0.0f;
            }
            else
            {
                animate -= Time.deltaTime;
                if (animate < 0)
                    animate = 0.0f;
            }
            float disInterval = screenHeight*2;//애니메이션 속도 조절
            for (int i = 0; i < btnLst.Count; i++)
            {
                Vector3 tempPos = aniTargetPosLst[i];
                tempPos.x=tempPos.x + (disInterval * (animate*Mathf.Abs(animate)));
                btnLst[i].transform.localPosition = tempPos;
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        if (InputMgr.Instance.ClickDown())
        {
            
            Vector3 temp=InputMgr.Instance.curPosition;
            Debug.Log(screenWidth - screenHeight / 2);
            if (temp.x < screenWidth / 2 - screenHeight / 2)
            {
                Debug.Log("Left");
                if (page > 0)
                {
                    page--;
                    DeleteAllBtn();
                    SetLobby();
                    animate = -0.5f;
                }
            }
            else if (temp.x > screenHeight / 2 + screenWidth / 2)
            {
                Debug.Log("Right");
                if (page < maxPage)
                {
                    page++;
                    DeleteAllBtn();
                    SetLobby();
                    animate = 0.5f;
                }
            }
                
        }
       
    }
        
    private void DeleteAllBtn()
    {
        foreach(GameObject temp in btnLst)
        {
            Destroy(temp);
        }
        btnLst.Clear();
        aniTargetPosLst.Clear();
    }
    public void StartStage(int stageNum)
    {
        Debug.Log("게임 스타트" + stageNum.ToString());

        
    }
}
