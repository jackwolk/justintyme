using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    public GameObject invisibleObject;
    public GameObject player;
    public KeyCode key;
    public float cooldownTimer;
    private float timer;
    private bool doOnce;
    public Queue<int> playerHealth;
    public int backInTimeHealth;
    public Health health;

    private Queue<Vector2> playerPosition;
    enum AbilityState
    {
        ready,
        cooldown
    }

    AbilityState state = AbilityState.cooldown;

    private void Start()
    {
        backInTimeHealth = 10;
        playerPosition = new Queue<Vector2>();
        playerHealth = new Queue<int>();

        InvokeRepeating("moveInvisObject", 1, 1);
        InvokeRepeating("moveInvisObject2", 10, 1);
    }

    private void Update()
    {
        switch (state)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(key))
                {
                    timeTravel();

                    state = AbilityState.cooldown;
                }
                timer = cooldownTimer;
                break;
            case AbilityState.cooldown:
                if (doOnce == true)
                {
                    timer = 15;
                    doOnce = false;
                }
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
                break;
        }
    }
    private void moveInvisObject()
    {
        playerPosition.Enqueue(player.transform.position);
        playerHealth.Enqueue(health.currentHealth);

    }
    private void moveInvisObject2()
    {
        invisibleObject.transform.position = playerPosition.Dequeue();
        backInTimeHealth = playerHealth.Dequeue();

    }

    private void timeTravel()
    {
        player.transform.position = invisibleObject.transform.position;
        health.currentHealth = backInTimeHealth;
    }

}
