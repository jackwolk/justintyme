using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuData : MonoBehaviour
{
    public float level1Time;
    public float level2Time;
    public float level3Time;

    private const int tooBigTime = 1000000000;

    public int watchersKilled;
    public int tickersKilled;
    public int cooCoosKilled;
    public int enemiesKilled;

    public TextMeshProUGUI level1;
    public TextMeshProUGUI level2;
    public TextMeshProUGUI level3;

    //level 1 achievements
    public bool gold1 = false;
    public bool silver1 = false;
    public bool bronze1 = false;

    //level 2 achievements

    public bool gold2 = false;
    public bool silver2 = false;
    public bool bronze2 = false;

    //level 3 achievements

    public bool gold3 = false;
    public bool silver3 = false;
    public bool bronze3 = false;

     

    private void Awake()
    {
        level1Time = tooBigTime;
        level2Time = tooBigTime;
        level3Time = tooBigTime;

        int numData = FindObjectsOfType<MenuData>().Length;
        if (numData != 1)
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
        level1 = GameObject.Find("Level1").GetComponent<TextMeshProUGUI>();
        level2 = GameObject.Find("Level2").GetComponent<TextMeshProUGUI>();
        level3 = GameObject.Find("Level3").GetComponent<TextMeshProUGUI>();



        if (level1Time < tooBigTime)
        {
            level1.text = Mathf.FloorToInt(level1Time / 60).ToString("00") + ":" + (level1Time % 60).ToString("00.00");
            if (gold1 == true)
            {
                level1.color = new Color32(255, 215, 0, 255);
            }
            else if(silver1 == true)
            {
                level1.color = new Color32(192, 192, 192, 255);
            }
            else if(bronze1 == true)
            {
                level1.color = new Color32(205, 127, 50, 255);
            }
            else
            {
                level1.color = new Color32(255, 255, 255, 255);
            }


        }

        if (level2Time < tooBigTime)
        {
            level2.text = Mathf.FloorToInt(level2Time / 60).ToString("00") + ":" + (level2Time % 60).ToString("00.00");
            if (gold2 == true)
            {
                level2.color = new Color32(255, 215, 0, 255);
            }
            else if (silver2 == true)
            {
                level2.color = new Color32(192, 192, 192, 255);
            }
            else if (bronze2 == true)
            {
                level2.color = new Color32(205, 127, 50, 255);
            }
            else
            {
                level2.color = new Color32(255, 255, 255, 255);
            }
        }

        if (level3Time < tooBigTime)
        {
            level3.text = Mathf.FloorToInt(level3Time / 60).ToString("00") + ":" + (level3Time % 60).ToString("00.00");
            if (gold3 == true)
            {
                level3.color = new Color32(255, 215, 0, 255);
            }
            else if (silver3 == true)
            {
                level3.color = new Color32(192, 192, 192, 255);
            }
            else if (bronze3 == true)
            {
                level3.color = new Color32(205, 127, 50, 255);
            }
            else
            {
                level3.color = new Color32(255, 255, 255, 255);
            }
        }

        Level1Achievements();
    }




    private void Level1Achievements()
    {
        if(level1Time < 60)
        {
            gold1 = true;
            silver1 = true;
            bronze1 = true;
        }
        else if(level1Time < 90)
        {
            silver1 = true;
            bronze1 = true;
        }
        else if(level1Time < 120)
        {
            bronze1 = true;
        }
    }

    private void Level2Achievements()
    {
        if (level2Time < 60)
        {
            gold2 = true;
            silver2 = true;
            bronze2 = true;
        }
        else if (level2Time < 90)
        {
            silver2 = true;
            bronze2 = true;
        }
        else if (level2Time < 120)
        {
            bronze2 = true;
        }
    }

    private void Level3Achievements()
    {
        if (level3Time < 60)
        {
            gold3 = true;
            silver3 = true;
            bronze3 = true;
        }
        else if (level3Time < 90)
        {
            silver3 = true;
            bronze3 = true;
        }
        else if (level3Time < 120)
        {
            bronze3 = true;
        }
    }
}


