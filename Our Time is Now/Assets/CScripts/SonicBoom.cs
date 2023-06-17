using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicBoom : MonoBehaviour
{
    public Transform player;
    Rigidbody2D rb;
    Vector3 moveDirection;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        moveDirection = direction;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * 5f, moveDirection.y * 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Health health;
        health = collision.GetComponent<Health>();
        if (collision.GetComponent<CooCoo>() == null && collision.GetComponent<Boss3>() == null) 
        {
            if(health != null) { health.GetHit(2, gameObject); }
            Destroy(gameObject);
        }
        
    }

}
