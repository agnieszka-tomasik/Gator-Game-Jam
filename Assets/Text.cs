using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Text : MonoBehaviour
{
    public string text;
    public Text m_myText;
    bool seenDoor;

    void Start()
    {
        //Text sets your text to say this message
        m_myText.text = "WASD or arrows to walk\nE to stun\nQ to capture";
        seenDoor = false;
    }

    void Update()
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.name == "PapaWiz")
            {
                m_myText.text = "Please help me open this door.\n You will need to collect three artifacts to get inside.";
            }
            
        }
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.name == "Barrier" && !seenDoor)
            {
                seenDoor = true;
                m_myText.text = "Open smaller doors by collecting monsters.\n Use E to stun, then Q to capture.";
            }
        }
    }
}
