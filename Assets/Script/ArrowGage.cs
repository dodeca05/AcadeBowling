using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGage : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> gages;

    private Transform tr;
    private float hsx;
    void Start()
    {
        tr = GetComponent<Transform>();
        hsx = tr.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i < gages.Count; i++)
        {
            if (tr.localScale.x >= (float)1 / gages.Count * (i + 1))
            {
                gages[i].SetActive(true);
            }
            else
                gages[i].SetActive(false);
        }
    }
}
