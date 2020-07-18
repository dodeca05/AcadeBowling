using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPad : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Isitonce;
    public bool All;
    private bool once;
    void Start()
    {
        once = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("파워패드 충돌");
        if (Isitonce)
        {
            if (once) return;
            once = true;
        }
        if (collision.gameObject.tag == "Player" || All)
        {

            Rigidbody ballrig = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 power = ballrig.velocity * 500;
            power.y = 0;
            power = power / power.magnitude * 10000;
            Debug.Log("Get Power " + power);
            ballrig.AddForce(power);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("파워패드 충돌");
        if (Isitonce)
        {
            if (once) return;
            once = true;
        }
        if (collision.gameObject.tag == "Player" || All)
        {
            
            Rigidbody ballrig = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 power = ballrig.velocity * 500;
            power.y = 0;
            power = power / power.magnitude * 10000;
            Debug.Log("Get Power "+power);
            ballrig.AddForce(power);
        }
    }
}
