using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouvementScript : MonoBehaviour
{
    public Rigidbody rb;
    public float sideMouvementForce = 400f;
    public float forwardForce = 2000f;
    public float jumpForce = 500f;
    public int jumpCount = 1;

    // Update is called once per frame
    void FixedUpdate()
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
        if (Input.GetKey(KeyCode.Space) && jumpCount>0)
        {
            rb.AddForce(0,jumpForce* Time.deltaTime, 0 , ForceMode.Impulse);
            jumpCount -= 1;
        }
        if (Input.GetKey("r"))
        {
            ResetGame();
        }
    }

    private void ResetGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/SampleScene");

    }
    private void OnCollisionEnter(Collision collisionEvent)
    {
        if (collisionEvent.gameObject.name == "Ground")
        {
            jumpCount = 1;
        }
        if (collisionEvent.gameObject.name == "Obstacles")
        {
            ResetGame();
            Debug.Log("GAME OVER");
        }
    }
}
