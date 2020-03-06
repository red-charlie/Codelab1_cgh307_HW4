using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //very simple and similar to the one in class code

    Rigidbody2D rb;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * speed); 
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.down * speed); 
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * speed); 
        }

        if (Input.GetKey(KeyCode.D)) 
        {
            rb.AddForce(Vector2.right * speed); 
        }
    }
}
