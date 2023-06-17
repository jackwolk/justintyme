using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticker : MonoBehaviour
{
    Vector2 moveDirection;
    public PlayerInRange isPlayerinRange;
    public Health _health;
    public Rigidbody2D rb;
    float moveX, moveY;
    Transform player;
    public Transform circleOrigin;
    public float radius;
    public GameObject _player;
    public Animator _animator;
    public string currentAnimation;



    private void Start()
    {
        _player = GameObject.Find("Player");

        moveX = Random.Range(-1, 2);
        moveY = Random.Range(-1, 2);

        player = GameObject.FindGameObjectWithTag("Player").transform;
        _animator = gameObject.GetComponent<Animator>();

        ChangeAnimationState("Running");
    }

    private void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        moveDirection = direction;

        if(_health.currentHealth <= 0)
        {
            ChangeAnimationState("Explode");
        }
    }
    private void FixedUpdate()
    {
        if(_health.isDead == true)
        {
            rb.velocity = new Vector2(0, 0);
        }
        else if(isPlayerinRange.canSeePlayer)
        {
            StopAllCoroutines();
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * 2;
        }
        else
        {
            StartCoroutine(ChangeDirection());

            rb.velocity = new Vector2(moveX, moveY);
        }
            


        
    }

    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(2);
        moveX = Random.Range(-1, 2);
        moveY = Random.Range(-1, 2);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {

            Health health;
            health = collider.GetComponent<Health>();
            if(collider.GetComponent<PlayerMovement>() != null)
            {
                ChangeAnimationState("Explode");
                health.GetHit(3, gameObject);
                _health.GetHit(5, _player);
            }
            

        }

    }
}
