using System;
using System.Collections;
using System.Collections.Generic;
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
        if (collisionEvent.gameObject.layer == 7)
        {
            Debug.Log("You can now jump once.");
            jumpCount = 1;
        }
        if (collisionEvent.gameObject.layer == 8)
        {
            Debug.Log("GAME OVER");
            ResetGame();
        }

        if (collisionEvent.gameObject.layer == 9)
        {
            collisionEvent.gameObject.SetActive(false);
            Debug.Log("BONUS");
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x*2, gameObject.transform.localScale.y*2, gameObject.transform.localScale.z*2);
        }
    }
}
