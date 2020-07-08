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
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0,1.5f,0);
    }

    // Update is called once per frame
    void Update()
    {
        float rx = transform.eulerAngles.x;
        if (rx > 180)
        {
            rx = 360 - rx;
        }
        
        float ry = transform.eulerAngles.y;
        if (ry > 180)
        {
            ry = 360 - ry;
        }

        if (isItDown==false && (Mathf.Abs(rx) >= 30  || Mathf.Abs(ry) >= 30 || GetComponent<Rigidbody>().velocity.magnitude>5.0f))
        {
            Debug.Log(gameObject.name + "is goal"+rx+" "+ry);
            Debug.Log(Mathf.Abs(transform.eulerAngles.x) +"/"+Mathf.Abs(transform.eulerAngles.z));
            isItDown = true;
            gm.AddScore();
        }
    }
}
