using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FloatyBoi : MonoBehaviour
{
    public GameObject amulet;
    public GameObject player;

    public bool stunned = false;
    public double stunTimer = 0;

    public bool summoned = false;
    public float summonSpeed = 50.0f;

    public float movementSpeed = 0.04f;
    public float x;
    public float y;
    public double radius;


    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        y = 0;
    }

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

        float theta = (Time.fixedTime % 180) * 2;
        radius = Math.Cos(theta * 3);
        x = (float)(radius * Math.Cos(theta));
        y = (float)(radius * Math.Sin(theta));

        //update the position
        transform.position = transform.position + new Vector3(y * movementSpeed, x * movementSpeed, 0);

    }
}
