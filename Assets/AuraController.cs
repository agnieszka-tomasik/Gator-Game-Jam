using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraController : MonoBehaviour
{

    public GameObject amulet;
    public Transform playerPos;
    public SpriteRenderer spriteRenderer;
    public AudioSource audioSource;
    public AudioClip zap;

    public double animationTimer = 0;
    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);

        if (Input.GetKey(KeyCode.E) && animationTimer <= 0)
        {
            this.animationTimer = 0.400;
            this.spriteRenderer.enabled = true;

            //zap
            audioSource.PlayOneShot(zap, 0.7f); 
        }

        if (animationTimer > 0)
        {
            GameObject[] triggeredEnemies = GameObject.FindGameObjectsWithTag("WithinReach");

            foreach (GameObject enemy in triggeredEnemies)
            {
                enemy.tag = "Stunned";
            }

            animationTimer -= Time.deltaTime;

            if (animationTimer <= 0)
            {
                animationTimer = 0;
                this.spriteRenderer.enabled = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.tag = "WithinReach";
        }
    }

    void onTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "WithinReach")
        {
            other.gameObject.tag = "Enemy";
        }
    }
}