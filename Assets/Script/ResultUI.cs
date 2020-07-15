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
    public Sprite Star;

    public GameObject[] starts;

    private RectTransform ani_target;

    private int score;
    private int maxScore;

    private int fin_ani;

    private const float ani_init=0.5f;
    private float ani_val;

    private void Start()
    {
        fin_ani = 0;
        ani_val = ani_init;
        ani_target = starts[0].GetComponent<RectTransform>();
    }
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
        if (score == 0) title.text = LanguageMgr.Instance.GetWord(LanguageMgr.Lcode.Fail);
        else
        {
            title.text = LanguageMgr.Instance.GetWord(LanguageMgr.Lcode.Success);

          
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

    void Update()
    {
        if (score > fin_ani)
        {

            if (ani_val - Time.deltaTime < ani_init / 2)
            {
                starts[fin_ani].GetComponent<Image>().sprite = Star;
            }
            ani_val -= Time.deltaTime;
            if (ani_val <= 0.0f)
            {
                ani_val = ani_init;
                fin_ani += 1;
                if (fin_ani < maxScore)
                    ani_target.sizeDelta = new Vector3(200, 200);
                    ani_target = starts[fin_ani].GetComponent<RectTransform>();
            }
            float temp = ani_val - (ani_init / 2);
            temp /= (ani_init / 2);
            ani_target.sizeDelta = new Vector3(200, 200) * (temp * temp);
        }
    }
}
