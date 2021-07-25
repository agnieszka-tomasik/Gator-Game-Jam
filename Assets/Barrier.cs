using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public int soulReq;
    public PlayerController player;
    
    // Update is called once per frame
    void Update()
    {
        if (player.GetSoulCount() >= soulReq)
        {
            // open door
            Debug.Log("Door Open");
            Destroy(gameObject, 1);
        }
    }
}
