using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public double soulCount;
    public bool relic1;
    public bool relic2;
    public bool relic3;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {

            rb.velocity = new Vector2(-10, rb.velocity.y);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {

            rb.velocity = new Vector2(10, rb.velocity.y);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {

            rb.velocity = new Vector2(rb.velocity.x, 30);

        }
        

    }

    void setSoulCount(double soulCount)
    {
        this.soulCount = soulCount;
    }

    public double getSoulCount()
    {
        return this.soulCount;
    }

    public void Ouchie ()
    {
        // player gets thrown in the opposite direction they were originally going (knockback)
        Debug.Log("ouchie!");
        

    }

    public void addRelic (int number)
    {
        if (number == 1)
        {
            relic1 = true;
        }
        else if (number == 2)
        {
            relic2 = true;
        }
        else
        {
            relic3 = true;
        }
    }
}
