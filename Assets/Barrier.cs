using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public int soulReq;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.getSoulCount() >= soulReq)
        {
            // open door
            Debug.Log("aldskfl");
            Destroy(gameObject, 1);
        }
    }
}
