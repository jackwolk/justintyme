using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public Health health;
    public int moveX;
    public int moveY;
    Rigidbody2D rb;
    Animator _animator;
    string currentAnimation;
    public GameObject winScreen;
    public GameObject attack;
    public HealthBarUI healthbarUI;

    public float timer;
    float maxTimer;

    private void Start()
    {
        healthbarUI.SetMaxHealth(health.maxHealth);
        health = gameObject.GetComponent<Health>();
        _animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        ChangeAnimationState("GreenFlying");
        moveX = 1;
        moveY = 0;

        InvokeRepeating("ChangeDirection", 0f, .5f);
        InvokeRepeating("Attack", 0f, .5f);
        timer = 60;
        maxTimer = 60;
    }


    private void Update()
    {
        healthbarUI.SetHealth(health.currentHealth);
        timer -= Time.deltaTime;

        if(timer > ((maxTimer / 3) * 2))
        {
            ChangeAnimationState("GreenFlying");
        }
        else if(timer > (maxTimer / 3))
        {
            ChangeAnimationState("YellowFlying");
        }
        else
        {
            ChangeAnimationState("RedFlying");
        }


        if (health.currentHealth <= 0)
        {
            StopAllCoroutines();
            Time.timeScale = 0;
            winScreen.active = true;
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX * 2, moveY * 2);
    }


    void ChangeDirection()
    {
        moveX = Random.Range(-1, 2);
        moveY = Random.Range(-1, 2);
    }

    void Attack()
    {
        int attack = 1;

        if(attack == 1)
        {
            Attack1();
        }

    }

    void Attack1()
    {
        Instantiate(attack, gameObject.transform.position, Quaternion.identity);
        Instantiate(attack, gameObject.transform.position, Quaternion.identity);
        Instantiate(attack, gameObject.transform.position, Quaternion.identity);
        Instantiate(attack, gameObject.transform.position, Quaternion.identity);
        Instantiate(attack, gameObject.transform.position, Quaternion.identity);
        
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

}
