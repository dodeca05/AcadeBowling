using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 moveDir;
    public float moveSpeed;

    private float time;
    private Vector3 firstPos;
   
    void Start()
    {
        time = 0.0f;
        firstPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += moveDir*moveSpeed*Time.deltaTime;

        time += Time.deltaTime;

        if (time > 2.5f)
        {
            time = 0;
            transform.localPosition = firstPos;
        }
        
    }
}
