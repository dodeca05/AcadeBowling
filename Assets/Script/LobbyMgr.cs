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
    public GameObject leftArrow;
    public GameObject rightArrow;
    public GameObject updateNote;
    public Sprite clearSp;
    public Sprite nonClearSp;

    private const int STAGE_PER_PAGE=20;
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
        /*
        if (SaveMgr.Instance.GetStage()>SaveMgr.MAXSTAGE)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }*/
        //PlayerPrefs.DeleteAll();

        

        if (!PlayerPrefs.HasKey("FollowCam")) 
        {
            PlayerPrefs.SetInt("FollowCam", 1);
        }

        if (!PlayerPrefs.HasKey("BallOverLap"))
        {
            PlayerPrefs.SetInt("BallOverLap", 1);
        }
        screenHeight = Screen.height;
        screenWidth = Screen.width;

        maxPage = Mathf.Max((SaveMgr.Instance.GetStage()-1) / STAGE_PER_PAGE,0);
        Debug.Log("MaxPage=" + maxPage);
        btnLst = new List<GameObject>();
        aniTargetPosLst = new List<Vector3>();

        SetLobby();
        animate = 0.4f;

        rightArrow.transform.localPosition = new Vector3(screenHeight+(screenWidth - screenHeight)/2 , 0)/2;

        leftArrow.transform.localPosition = rightArrow.transform.localPosition * -1;
        Time.timeScale = 1.0f;

        PlayerPrefs.Save();



        GameObject.Find("ADS").GetComponent<ADMgr>().BannerShow();
    }

    public void SetLobby()
    {
        stage = SaveMgr.Instance.GetStage();
        Vector3 pos = buttonPrefab.transform.localPosition;
        //Debug.Log(pos);
        
        int ScH = screenHeight;
        int ScW = screenWidth;
        int lastPage = Mathf.Min(stage, STAGE_PER_PAGE * (page + 1) - 1);
        for (int i = STAGE_PER_PAGE * page; i <= lastPage; i++)
        {
            int row = (i% STAGE_PER_PAGE) % 5 - 2;
            int col = (i% STAGE_PER_PAGE) / 5 - 2;
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
            int score = SaveMgr.Instance.GetScore(i);
            tempButton.GetComponent<StageStartButton>().SetStar(score);
           

            if (score == 0)
                tempButton.GetComponent<Image>().sprite = nonClearSp;
            tempText.text = btnText;


        }

        if (lastPage == stage && PlayerPrefs.GetInt("S" + stage) > 0)
            updateNote.SetActive(true);
        else
            updateNote.SetActive(false);

        if (page == 0) leftArrow.SetActive(false);
        else leftArrow.SetActive(true);

        if (page == maxPage) rightArrow.SetActive(false);
        else rightArrow.SetActive(true);
        
        
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
            Debug.Log(temp);
            Debug.Log(screenWidth - screenHeight / 2);
            if (temp.x < Screen.width / 2 - Screen.height / 2)
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
