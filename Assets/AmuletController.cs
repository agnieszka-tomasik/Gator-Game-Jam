using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmuletController : MonoBehaviour
{

    public GameObject player;
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localPosition = new Vector3(-2, transform.localPosition.y, transform.localPosition.z);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.localPosition = new Vector3(2, transform.localPosition.y, transform.localPosition.z);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            GameObject[] stunnedEnemies = GameObject.FindGameObjectsWithTag("Stunned");

            foreach (GameObject enemy in stunnedEnemies)
            {
                enemy.tag = "DeathsDoor";
            }
        }
    }
}
