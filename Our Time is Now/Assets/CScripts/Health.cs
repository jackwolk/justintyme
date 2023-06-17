using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public MenuData menuData;
    public Collider2D hitbox;
    public GameObject itemdrop;

    [SerializeField] public int currentHealth, maxHealth;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    //Change for each enemy with different length of death animation
    public float deathAnimTime;

    public bool isInvulnerable = false;
    public bool isBoss;
    public Data data;

    [SerializeField]
    public bool isDead = false;


    private void Start()
    {
        menuData = GameObject.Find("MenuData").GetComponent<MenuData>();
        data = GameObject.Find("Data").GetComponent<Data>();
        InitializeHealth(maxHealth);
        if(gameObject.GetComponent<PlayerMovement>() != null)
        {
            InitializeHealth(data.health);
        }
    }


    public void InitializeHealth(int healthValue)
    {
        currentHealth = healthValue;
        
        isDead = false;
    }

    public void GetHit(int damage, GameObject sender)
    {
        if (isDead)
            return;
        if (sender.layer == gameObject.layer)
            return;
        if (isInvulnerable)
            return;

        currentHealth -= damage;

        if (currentHealth > 0)
        {
            OnHitWithReference?.Invoke(sender);

        }
        else
        {
            hitbox.enabled = false;
            OnDeathWithReference?.Invoke(sender);
            isDead = true;
            StartCoroutine(WaitForDeath());

        }

    }

    private IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(deathAnimTime);

        dropItem();
        Debug.Log("Should have worked");
        Destroy(gameObject);

        if(gameObject.name == "Watcher(Clone)")
        {
            menuData.watchersKilled += 1;
        }
        else if(gameObject.name == "Ticker(Clone)")
        {
            menuData.tickersKilled += 1;
        }


        if (isBoss)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Watcher");
            foreach (GameObject enemy in enemies)
                GameObject.Destroy(enemy);
        }

    }

    private void dropItem()
    {
        Instantiate(itemdrop, gameObject.transform.position, Quaternion.identity);
    }


}
