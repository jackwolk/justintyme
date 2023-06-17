using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    int randx;
    int randy;
    int watcherSpawn;
    bool isAttacking;
    public bool isAnimationOver;

    public GameObject minionSpawnPoint;
    public GameObject boss;

    Health health;

    //Animation variables
    Animator _animator;
    string currentAnimation;
    const string BOSS_IDLE = "Idle";
    public string[] bossAttacks;



    public GameObject laser1Sprite;
    public GameObject laser2Sprite;

    public Vector2 position;

    public HealthBarUI healthbarUI;
    public GameObject winScreen;
 

    // Start is called before the first frame update
    void Start()
    {
        health = gameObject.GetComponent<Health>();
        _animator = gameObject.GetComponent<Animator>();
        ChangeAnimationState(BOSS_IDLE);
        InvokeRepeating("RandomBossPos", 1, 1f);
        InvokeRepeating("StartAttack", 10, 16f);

        healthbarUI.SetMaxHealth(health.maxHealth);



    }

    private void Update()
    {

        healthbarUI.SetHealth(health.currentHealth);
        position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

        if(health.currentHealth <= 0)
        {
            StopAllCoroutines();
            laser1Sprite.transform.position = new Vector3(20, 20, 0);
            laser1Sprite.transform.rotation = new Quaternion(0, 0, 0, 0);

            laser2Sprite.transform.position = new Vector3(20, 20, 0);
            laser2Sprite.transform.rotation = new Quaternion(0, 0, 0, 0);
            Time.timeScale = 0;
            winScreen.active = true;
        }

    }


    private void RandomBossPos()
    {
        if (isAttacking == false)
        {
            health.isInvulnerable = true;
            randx = Random.Range(-3, 3);
            randy = Random.Range(-3, 3);

            gameObject.transform.position = new Vector3(randx, randy);

            watcherSpawn += 1;

            if (watcherSpawn % 7 == 0)
            {
                Instantiate(minionSpawnPoint, boss.transform.position, Quaternion.identity);
            }
        }
    }


    

    private void StartAttack()
    {
        isAttacking = true;
        int attack = Random.Range(0, bossAttacks.Length);
        health.isInvulnerable = false;

        ChangeAnimationState(bossAttacks[attack]);


        if (attack == 0)
        {
            StartCoroutine(Attack1());
        }
        else if(attack == 1)
        {
            StartCoroutine(Attack2());
        }
        else if(attack == 2)
        {
            StartCoroutine(Attack3());
        }
        else if (attack == 3)
        {
            StartCoroutine(Attack4());
        }
        else if (attack == 4)
        {
            StartCoroutine(Attack5());
        }
        else if (attack == 5)
        {
            StartCoroutine(Attack6());
        }
        else if (attack == 6)
        {
            StartCoroutine(Attack7());
        }
        else if (attack == 7)
        {
            StartCoroutine(Attack8());
        }

        StartCoroutine(EndAttacks());

    }


    IEnumerator EndAttacks()
    {
        yield return new WaitForSeconds(4);

        StopAllCoroutines();
        ChangeAnimationState(BOSS_IDLE);
        laser1Sprite.transform.position = new Vector3(20, 20, 0);
        laser1Sprite.transform.rotation = new Quaternion(0, 0, 0, 0);

        laser2Sprite.transform.position = new Vector3(20, 20, 0);
        laser2Sprite.transform.rotation = new Quaternion(0, 0, 0, 0);


        isAttacking = false;
    }

    IEnumerator Attack1()
    {
        yield return new WaitForSeconds(1);

        laser1Sprite.transform.position = gameObject.transform.position + new Vector3(0, 3.4f, 0);

        laser2Sprite.transform.position = gameObject.transform.position + new Vector3(3.5f, -.1f, 0);
        laser2Sprite.transform.Rotate(new Vector3(0, 0, 90));
    }

    IEnumerator Attack2()
    {
        yield return new WaitForSeconds(1);

        laser1Sprite.transform.position = gameObject.transform.position + new Vector3(0, 3.4f, 0);

        laser2Sprite.transform.position = gameObject.transform.position + new Vector3(0, -3.7f, 0);
        laser2Sprite.transform.Rotate(new Vector3(0, 0, 180));
    }

    IEnumerator Attack3()
    {
        yield return new WaitForSeconds(1);

        laser1Sprite.transform.position = gameObject.transform.position + new Vector3(-3.6f, -.1f, 0);
        laser1Sprite.transform.Rotate(new Vector3(0, 0, 90));

        laser2Sprite.transform.position = gameObject.transform.position + new Vector3(3.6f, -.1f, 0);
        laser2Sprite.transform.Rotate(new Vector3(0, 0, 270));
    }

    IEnumerator Attack4()
    {
        yield return new WaitForSeconds(1);

        laser1Sprite.transform.position = gameObject.transform.position + new Vector3(2.55f, 2.4f, 0);
        laser1Sprite.transform.Rotate(new Vector3(0, 0, -45));

        laser2Sprite.transform.position = gameObject.transform.position + new Vector3(3.6f, -.1f, 0);
        laser2Sprite.transform.Rotate(new Vector3(0, 0, 90));
    }

    IEnumerator Attack5()
    {
        yield return new WaitForSeconds(1);

        laser1Sprite.transform.position = gameObject.transform.position + new Vector3(2.55f, 2.4f, 0);
        laser1Sprite.transform.Rotate(new Vector3(0, 0, -45));

        laser2Sprite.transform.position = gameObject.transform.position + new Vector3(-2.6f, -2.7f, 0);
        laser2Sprite.transform.Rotate(new Vector3(0, 0, 135));

    }

    IEnumerator Attack6()
    {
        yield return new WaitForSeconds(1);

        laser1Sprite.transform.position = gameObject.transform.position + new Vector3(-3.6f, -.1f, 0);
        laser1Sprite.transform.Rotate(new Vector3(0, 0, 90));


        laser2Sprite.transform.position = gameObject.transform.position + new Vector3(0, -3.7f, 0);
        laser2Sprite.transform.Rotate(new Vector3(0, 0, 180));
    }

    IEnumerator Attack7()
    {
        yield return new WaitForSeconds(1);

        laser1Sprite.transform.position = gameObject.transform.position + new Vector3(-2.6f, 2.45f, 0);
        laser1Sprite.transform.Rotate(new Vector3(0, 0, 45));

        laser2Sprite.transform.position = gameObject.transform.position + new Vector3(2.6f, -2.7f, 0);
        laser2Sprite.transform.Rotate(new Vector3(0, 0, 225));

    }

    IEnumerator Attack8()
    {
        yield return new WaitForSeconds(1);

        laser1Sprite.transform.position = gameObject.transform.position + new Vector3(-2.6f, 2.45f, 0);
        laser1Sprite.transform.Rotate(new Vector3(0, 0, 45));

        laser2Sprite.transform.position = gameObject.transform.position + new Vector3(2.55f, 2.4f, 0);
        laser2Sprite.transform.Rotate(new Vector3(0, 0, -45));
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
