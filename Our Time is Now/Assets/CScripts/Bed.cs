using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed : MonoBehaviour
{
    private int randNum;

    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public GameObject pos4;
    private PlayerInRange inRange;

    public bool isLevel1;


    private void Start()
    {
        inRange = gameObject.GetComponent<PlayerInRange>();

        randNum = Random.Range(1, 4);

        if (randNum == 1) 
        {
            gameObject.transform.position = pos1.transform.position;

        }
        else if (randNum == 2)
        {
            gameObject.transform.position = pos2.transform.position;

        }
        else if (randNum == 3)
        {
            gameObject.transform.position = pos3.transform.position;

        }
        else if (randNum == 4)
        {
            gameObject.transform.position = pos4.transform.position;

        }
    }

    private void Update()
    {
        if (inRange.canSeePlayer == true && Input.GetKeyDown(KeyCode.E)){

            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level 1"))
            {
                SceneManager.LoadScene("Boss Fight");
            }
            else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level2"))
            {
                SceneManager.LoadScene("Boss Fight 2");
            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level3"))
            {
                SceneManager.LoadScene("3BossFight");
            }
            else
            {
                SceneManager.LoadScene("Menu");
            }


        }


    }


}
