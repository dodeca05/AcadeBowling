using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KegelMgr : MonoBehaviour
{
    private GameMgr gm;
    private bool isItDown;
    // Start is called before the first frame update
    void Start()
    {
        gm=GameObject.Find("GameMgr").GetComponent<GameMgr>();
        isItDown = false;
        //GetComponent<Rigidbody>().centerOfMass = new Vector3(0,0.5f,0);
    }

    // Update is called once per frame
    void Update()
    {

        float rx = Mathf.Abs(transform.eulerAngles.x);
        float ry = Mathf.Abs(transform.eulerAngles.y);
        float rz = Mathf.Abs(transform.eulerAngles.z);
        
        if (rx > 180)
        {
            rx = 360 - rx;
        }
        
        
        if (ry > 180)
        {
            ry = 360 - ry;
        }

        if(rz>180)
        {
            rz = 360 - rz;

        }
        Debug.Log(gameObject.name +" "+ rx +" "+ ry);
        if (isItDown==false && (Mathf.Abs(rz)>=30 || Mathf.Abs(rx) >= 30  || Mathf.Abs(ry) >= 30 || GetComponent<Rigidbody>().velocity.magnitude>5.0f))
        {
            Debug.Log(gameObject.name + "is goal"+rx+" "+ry);
            Debug.Log(Mathf.Abs(transform.eulerAngles.x) +"/"+Mathf.Abs(transform.eulerAngles.z));
            isItDown = true;
            gm.AddScore();
        }
    }
}
