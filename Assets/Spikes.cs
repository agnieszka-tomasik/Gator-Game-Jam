using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public GameObject player;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            player.SendMessage("Ouchie");
        }
    }
}
