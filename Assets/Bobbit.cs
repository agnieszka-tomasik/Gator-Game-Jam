using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bobbit : MonoBehaviour
{
    public GameObject amulet;
    public GameObject player;

    public bool stunned = false;
    public double stunTimer = 0;

    public bool summoned = false;
    public float summonSpeed = 50.0f;

    public float movementSpeed = 1f;
    public bool vertical;
    public bool downright;
    

    // Update is called once per frame
    void Update()
    {
        if (this.tag == "Stunned")
        {
            if (!stunned)
            {
                stunTimer = 3.00;
                stunned = true;
            }

            stunTimer -= Time.deltaTime;

            // Recover from stun
            if (stunTimer <= 0)
            {
                stunTimer = 0;
                stunned = false;
                this.tag = "Enemy";
            }
        }

        if (this.tag == "DeathsDoor")
        {
            if (!summoned)
            {
                Destroy(this.GetComponent<Rigidbody2D>());
                Destroy(this.GetComponent<BoxCollider2D>());
                summoned = true;
            }

            float step = summonSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, amulet.transform.position, step);

            if (Vector3.Distance(transform.position, amulet.transform.position) <= 0.1)
            {
                player.SendMessage("SoulCaptured");
                Destroy(this.gameObject);
            }
        }

        //get the Input from Horizontal axis
        float horizontalInput = 1;
        //get the Input from Vertical axis
        float verticalInput = 1;

        if (vertical)
        {
            horizontalInput = 0;
        }
        else
        {
            verticalInput = 0;
        }
        if (downright)
        {
            horizontalInput *= -1;
            verticalInput *= -1;
        }
        if ((Time.fixedTime % 4) < 2)
        {
            horizontalInput *= -1;
            verticalInput *= -1;
        }

        //update the position
        transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);

    }
}
