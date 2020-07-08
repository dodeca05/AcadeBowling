using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTest : MonoBehaviour
{
    private LineRenderer lr;
    private Queue<Vector3> qPos;

    private int qSize = 20;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        qPos = new Queue<Vector3>();
        for (int i = 0; i < qSize; i++)
            qPos.Enqueue(transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        qPos.Dequeue();
        qPos.Enqueue(transform.position);
        Vector3[] posAry = qPos.ToArray();
        lr.SetPositions(posAry);


    }
}
