using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementScript : MonoBehaviour
{
    public Rigidbody rb;
    public float sideMouvementForce = 400f;
    public float forwardForce = 2000f;
    

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, forwardForce * Time.deltaTime);
        if (Input.GetKey("d"))
        {
            rb.AddForce(sideMouvementForce* Time.deltaTime,0, 0 , ForceMode.Force);

        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideMouvementForce* Time.deltaTime,0, 0 , ForceMode.Force);

        }
    }
}
