using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    Health health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Health health;
        if (collision.GetComponent<Health>())
        {
            health = collision.GetComponent<Health>();
            health.GetHit(6, gameObject);
        }
        
    }

}
