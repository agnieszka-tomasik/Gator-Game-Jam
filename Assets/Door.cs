using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public PlayerController player;

    // Update is called once per frame
    void Update()
    {
        if (player.GetRelicCount() >= 3)
        {
            // open door
            //Debug.Log("Door Open");
            Destroy(gameObject, 1);
        }
    }
}
