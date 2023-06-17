using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Animator _animator;
    public float delay = 0.3f;
    private bool attackReady;
    public AudioSource hitsound;
    public AudioSource misssound;

    public CircleCollider2D hitbox;



    private void Start()
    {
        hitbox.enabled = false;
        attackReady = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    public void Attack()
    {

        if (attackReady == true)
        {
            hitbox.enabled = true;
            _animator.SetTrigger("Attack");
            Debug.Log("Attacking");
            attackReady = false;
            StartCoroutine(TurnOffHitbox());

            StartCoroutine(DelayAttack());

        }
        else
        {
            return;
        }
    }

    private IEnumerator TurnOffHitbox()
    {
        yield return new WaitForSeconds(.2f);
        hitbox.enabled = false;
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackReady = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health;
        health = collision.GetComponent<Health>();

        if (collision.GetComponent<PlayerMovement>() == null && collision.isTrigger == false)
        {
            hitsound.Play();
            health.GetHit(2, gameObject);
        }


    }
}
