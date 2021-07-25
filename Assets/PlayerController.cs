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
    public AudioSource audioSource;
    public AudioClip jump, hit, soulCapture;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }
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
                audioSource.PlayOneShot(jump,0.4f);
            }

        }
    }

    void SoulCapture()
    {
        this.soulCount++;
        audioSource.PlayOneShot(soulCapture, 0.4f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
            audioSource.PlayOneShot(hit, 0.4f);
        }
    }

    
}

