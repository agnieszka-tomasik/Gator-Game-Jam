using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relic : MonoBehaviour
{
    public PlayerController player;
    public int num;

    void OnTriggerEnter2D(Collider2D other)
    {
        // when the player walks on it,
        // put in inventory & delete
        player.addRelic(num);
        Destroy(gameObject);
    }
}
