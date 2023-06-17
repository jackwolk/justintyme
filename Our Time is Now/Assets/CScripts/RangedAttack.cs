using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{

    public Rigidbody2D rb;
    public int moveX, moveY;
    Animator _animator;
    string currentAnimation;
    int coinflip1;
    int coinflip2;

    private void Start()
    {
        StartCoroutine(SelfDestruct());

        coinflip1 = Random.Range(0, 2);
        coinflip2 = Random.Range(0, 2);

        if (coinflip1 == 1)
        {
            moveX = Random.Range(-1, 1);
        }
        else
        {
            moveX = 1;
        }

        if (coinflip2 == 1)
        {
            moveY = Random.Range(-1, 1);
            
        }
        else
        {
            moveY = 1;
        }

        if(moveX == 0 && moveY == 0)
        {
            moveX = 1;
            moveY = 1;
        }

        _animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        ChangeAnimationState("RangedAttack");
    }

    private void FixedUpdate()
    {

        
        rb.velocity = new Vector2(moveX * 5f, moveY * 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        Debug.Log("Hit");


            Health health;
            health = collision.GetComponent<Health>();
            if (collision.GetComponent<PlayerMovement>() != null)
            {
                 Debug.Log("Hit Player");
                health.GetHit(1, transform.gameObject);
                
            }
        

    }

    private void ChangeAnimationState(string newState)
    {
        if (newState == currentAnimation)
        {
            return;
        }

        _animator.Play(newState);
        currentAnimation = newState;

    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
