using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallKick : MonoBehaviour
{
    public float kickForce = 500f;      
    private Rigidbody ballRb;

    void Start()
    {
        ballRb = GameObject.FindWithTag("Ball").GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Vector3 direction = (ballRb.transform.position - transform.position).normalized;
            ballRb.AddForce(direction * kickForce);
        }
    }
   
}
