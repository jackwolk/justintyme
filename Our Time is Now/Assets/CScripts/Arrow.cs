using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * 10f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health;
        health = collision.GetComponent<Health>();

        if (collision.GetComponent<PlayerMovement>() == null && collision.isTrigger == false)
        {

            health.GetHit(1, gameObject);
            Destroy(gameObject);
        }
    }
}
