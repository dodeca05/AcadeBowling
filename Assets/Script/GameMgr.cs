using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public List<Rigidbody> kegelLst;
    public GameObject resultUI;
    public List<GameObject> moveObj;


    private GameObject ball;
    private LaunchCtrl ballCtrl;
    private Rigidbody ballRig;
    private int score = 0;
    private float coolTime = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 1.0f;
        int i_width = Screen.width;

        int i_height = Screen.height;

        Screen.SetResolution(i_width/ i_height * 720, 720, true);

        ball = GameObject.Find("Ball");
        ballCtrl = ball.GetComponent<LaunchCtrl>();
        ballRig = ball.GetComponent<Rigidbody>();
        GameObject [] tempLst= GameObject.FindGameObjectsWithTag("Kegel");
        resultUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ballCtrl.GetState() == LaunchCtrl.State.Launch)
        {
            Vector3 ballForce = ballRig.velocity;
            //Debug.Log("Force=" + ballForce.magnitude);
            coolTime += Time.deltaTime;
            if (coolTime < 1.5f) {
                return;
            }
            if (ballForce.magnitude < 1.0f || ball.transform.position.y < -10 || score==kegelLst.Count)
            {
                float vSum = 0.0f;
                foreach (Rigidbody temp in kegelLst)
                {
                    vSum += temp.velocity.magnitude;
                }
                //Debug.Log("Ball is stop"+vSum);
                bool objStop=true;
                foreach(GameObject temp in moveObj)
                {
                    if (temp.transform.position.y > -10.0f && temp.GetComponent<Rigidbody>().velocity.magnitude>1.0f)
                    {
                        objStop = false;
                        break;
                    }
                
                }

                if (((ballForce.magnitude < 1.0f   || vSum < 0.2f ) || score == kegelLst.Count || ball.transform.position.y < -10)&& objStop)
                {
                    resultUI.GetComponent<ResultUI>().SetResult(score, kegelLst.Count);
                    Debug.Log("setResult" + score + kegelLst.Count);
                    resultUI.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
        
        }
    }

    public void AddScore() {
        score++;
        Debug.Log("Now Score = "+score);
    }
    public int GetScore() {
        return score;
    }
}
