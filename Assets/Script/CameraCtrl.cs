using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{    
    public GameObject bollObj;
    public bool followCam;

    private LaunchCtrl boll;
    private Vector3 offset;
    private float smooth;
    private float smoothValue;
    // Start is called before the first frame update
    void Start()
    {
        boll = bollObj.GetComponent<LaunchCtrl>();
        smooth = 10f;
        smoothValue = 0f;

        offset = new Vector3(0, -55, 30);

        followCam = PlayerPrefs.GetInt("FollowCam") == 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (InputMgr.Instance.Click() && boll.GetState()!=LaunchCtrl.State.Aiming)
        {
            Vector3 curmovedis=InputMgr.Instance.curMoveDis;
         
            float Mx = curmovedis.x;
            float My = curmovedis.y;
            

            Vector3 moveVector = new Vector3(-Mx, 0, -My);
            transform.Translate(moveVector/10);
        }
        float Mh = InputMgr.Instance.zoom*-Time.deltaTime*10.0f;
        Vector3 tempPos = transform.position;
        transform.Translate(0, Mh, -Mh);
        if (transform.position.y < 5 || transform.position.y>180)
            transform.position = tempPos;
        if (boll.GetState() == LaunchCtrl.State.Launch && followCam)
        {
            Vector3 nowpos = transform.position;
            transform.position = Vector3.Lerp(nowpos, bollObj.transform.position-offset,Mathf.Min(1,smoothValue));
            if(smoothValue<1.0f)
                smoothValue += Time.deltaTime / smooth;
            if (InputMgr.Instance.Click())
                followCam = false;
        }
    }
}
