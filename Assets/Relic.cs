using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relic : MonoBehaviour
{
    public GameObject player;
    public int num;

    void OnTriggerEnter2D(Collider2D other)
    {
        // when the player walks on it,
        // put in inventory & delete
        player.SendMessage("AddRelic", num);
        Destroy(gameObject);
    }
}
