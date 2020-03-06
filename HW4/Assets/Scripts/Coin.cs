using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D colliderCoin;
    public float speed = 10f;
    public int coinValue = 10;
    public Text valueText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); ;
        colliderCoin = GetComponent<Collider2D>();
        valueText.text = "" + coinValue;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(Random.Range(-speed, speed), Random.Range(-speed, speed)));
    }

    private void OnCollisionEnter2D(Collision2D collision) //If another GameObject with a 2D Collider on it hits this GameObject's collider
    {

        //Debug.Log("I've been hit");

        if (collision.gameObject.name == "Player")
        {
            GameManager.instance.Score += coinValue; //add the coin value to my score
                                                     //GameManager.instance.Score++;

            Destroy(gameObject);
        }

    }
}
