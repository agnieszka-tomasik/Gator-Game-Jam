using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnCollisionEnter()
    {
        player.Ouchie();
        Debug.Log("oncollisionenter");
    }
}
