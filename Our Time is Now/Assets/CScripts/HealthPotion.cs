using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public HealthPotionUI healthPotionUI;

    private void Start()
    {
        healthPotionUI = GameObject.Find("Potion").GetComponent<HealthPotionUI>();
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            healthPotionUI.addCoins(1);
            Destroy(gameObject);
        }
        
    }
}
