using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public GameObject introScene;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        introScene.active = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PlayGame();
        }
    }

    void PlayGame()
    {
        Time.timeScale = 1;
        introScene.active = false;
    }
}
