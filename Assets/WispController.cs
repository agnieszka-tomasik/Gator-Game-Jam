using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispController : MonoBehaviour
{
    public GameObject amulet;
    public GameObject player;

    public bool stunned = false;
    public double stunTimer = 0;

    public bool summoned = false;
    public float speed = 50.0f;

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

            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, amulet.transform.position, step);

            if (Vector3.Distance(transform.position, amulet.transform.position) <= 0.1)
            {
                player.SendMessage("SoulCaptured");
                Destroy(this.gameObject);
            }
        }
    }

}
