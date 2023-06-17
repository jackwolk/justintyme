using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public Collider2D detection;
    public GameObject dialogueBox;
    public TextMeshProUGUI textDisplay;

    public string text;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            dialogueBox.active = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMovement>())
        {  
            dialogueBox.active = true;
            textDisplay.text = text;
        } 

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            dialogueBox.active = false;
        }
    }

}
