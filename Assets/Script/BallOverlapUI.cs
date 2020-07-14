using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOverlapUI : MonoBehaviour
{

    public GameObject ball;

    private LaunchCtrl lc;
    private int screenHeight;
    private int screenWidth;
    private float radius;

    // Start is called before the first frame update
    void Start()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
        lc = ball.GetComponent<LaunchCtrl>();

        radius= transform.gameObject.GetComponent<RectTransform>().rect.height/2;
        Debug.Log("radius="+ radius);
    }

    // Update is called once per frame
    void Update()
    {
        if (lc.GetState() != LaunchCtrl.State.Ready)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Vector3 overlapPos = Camera.main.WorldToScreenPoint(ball.transform.position);

            overlapPos.z = 0.0f;
            if (InputMgr.Instance.ClickDown() && Vector3.Distance(InputMgr.Instance.curPosition, overlapPos)<radius)
            {

              
                lc.SetAim();
               
            }

            overlapPos.x -= screenWidth / 2;
            overlapPos.y -= screenHeight / 2;
            
            transform.localPosition = overlapPos;
        }
    }
}
