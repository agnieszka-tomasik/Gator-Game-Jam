using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraController : MonoBehaviour
{
    public GameObject Player;
    public Transform playerPos;
    public SpriteRenderer spriteRenderer;
    public CircleCollider2D circleCollider;
    public double timer = 0;
    public List<GameObject> enemiesInTrigger = new List<GameObject>();

    private PlayerController playerController;


    void Start()
    {
        Debug.Log("Test", Player);
        this.playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        this.spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        this.circleCollider = gameObject.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);

        if (Input.GetKey(KeyCode.E) && timer == 0)
        {
            this.timer = 0.200;
            this.spriteRenderer.enabled = true;
        }

        if (timer > 0)
        {
            foreach (GameObject enemy in enemiesInTrigger)
            {
                Debug.Log("Deleting an enemy");
                enemiesInTrigger.Remove(enemy);
                Destroy(enemy);
                playerController.soulCount++;
            }

            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = 0;
                this.spriteRenderer.enabled = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered: " + other.gameObject.name);
        // If the enemy has entered the trigger sphere
        if (other.gameObject.tag == "Enemy")
        {
            // If the enemy is not already in the list
            if (!enemiesInTrigger.Contains(other.gameObject))
            {
                // Add him to the list
                enemiesInTrigger.Add(other.gameObject);
            }
        }
    }

    void onTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exited: " + other.gameObject.name);
        if (other.gameObject.tag == "Enemy")
        {
            enemiesInTrigger.Remove(other.gameObject);
        }
    }
}