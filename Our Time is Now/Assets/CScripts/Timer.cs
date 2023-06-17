using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    float time;
    public float startTime;
    public TextMeshProUGUI endofGameText;
    public Data data;
    public MenuData menuData;
    public Health player;

    private void Start()
    {
        data = GameObject.Find("Data").GetComponent<Data>();
        menuData = GameObject.Find("MenuData").GetComponent<MenuData>();

        time = data.time;
        player = GameObject.Find("Player").GetComponent<Health>();
    }

    private void Update()
    {
        time += Time.deltaTime;

        text.text = Mathf.FloorToInt(time/60).ToString("00") + ":" + (time%60).ToString("00.00");
        endofGameText.text = Mathf.FloorToInt(time / 60).ToString("00") + ":" + (time % 60).ToString("00.00");



    }

    private void OnDestroy()
    {
        data.time = time;
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Boss Fight"))
        {
            if(player.isDead != true)
            {
                if (menuData.level1Time > time)
                {
                    menuData.level1Time = time;
                }
            }
            

        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Boss Fight 2"))
        {
            if (player.isDead != true)
            {


                if (menuData.level2Time > time)
                {
                    menuData.level2Time = time;
                }
            }
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("3BossFight"))
        {

            if (player.isDead != true)
            {
                if (menuData.level3Time > time)
                {
                    menuData.level3Time = time;
                }
            }
            
        }
    }

}
