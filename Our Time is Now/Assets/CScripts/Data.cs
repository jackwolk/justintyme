using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour
{
    public int coins;
    public float time;
    public int health;
    public int healthPotions;

    private void Awake()
    {
        coins = 0;
        time = 0;
        health = 10;
        healthPotions = 0;

        int numData = FindObjectsOfType<Data>().Length;
        if(numData != 1)
        {
            Destroy(this.gameObject);
            Debug.Log("Destroyed noob");
        }
        else
        {

            DontDestroyOnLoad(gameObject);
        }



    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Menu"))
        {
            coins = 0;
            time = 0;
            health = 10;
            healthPotions = 0;
            Debug.Log("Set to Zero");
        }
    }
    }

