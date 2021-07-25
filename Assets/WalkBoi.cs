using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WalkBoi : MonoBehaviour
{
    public GameObject amulet;
    public GameObject player;

    public bool stunned = false;
    public double stunTimer = 0;

    public bool summoned = false;
    public float summonSpeed = 50.0f;

    public float movementSpeed = 100.0f;
    float step = 0.0f;

    Vector3 begin = new Vector3(45.0f, -11.0f, 0.0f);
    Vector3 end = new Vector3(55.0f, -11.0f, 0.0f);
    Vector3 targetPosition;
    bool start;


    // Start is called before the first frame update
    void Start()
    {
        start = false;
        targetPosition = begin;
        transform.position = new Vector3(50.0f, -11.0f, 0.0f);
    }

    // Update is called once per frame
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

        if (this.tag == "Enemy" || this.tag == "WithinReach")
        {
            step = 0.025f;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                if (start == true)
                {
                    start = false;
                    targetPosition = end;
                }
                else if (start == false)
                {
                    start = true;
                    targetPosition = begin;
                }
            }
        }        
    }
}