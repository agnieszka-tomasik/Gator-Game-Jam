using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public int jumpForce;
    private bool isJumping = false;
    private float maxSpeed = 10;
    public double soulCount = 0;
    public bool relic1;
    public bool relic2;
    public bool relic3;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            if (!isJumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 20), ForceMode2D.Impulse);
                isJumping = true;
            }
        }
    }

    void SoulCaptured()
    {
        this.soulCount++;
    }

    public double GetSoulCount()
    {
        return this.soulCount;
    }

    public double GetRelicCount()
    {
        int num = 0;
        if (relic1)
        {
            num++;
        }
        if (relic2)
        {
            num++;
        }
        if (relic3)
        {
            num++;
        }
        return num;
    }

    void Ouchie()
    {
        float scale = 1.0f;
        // player gets thrown in the opposite direction they were originally going (knockback)
        rb.velocity = new Vector2(rb.velocity.x * scale * -1, rb.velocity.y * scale * -1);
        Debug.Log("ouchie!");
    }

    void AddRelic(int number)
    {
        switch (number)
        {
            case 1:
                this.relic1 = true;
                break;
            case 2:
                this.relic2 = true;
                break;
            case 3:
                this.relic3 = true;
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") {
            this.isJumping = false;
        }
    }
}
