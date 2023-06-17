using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenButtons : MonoBehaviour
{
    public bool isPaused;
    public GameObject pausemenu;




    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pausemenu.active = false;
    }

    public void Pause() {
        Time.timeScale = 0f;
        isPaused = true;
        pausemenu.active = true;
    }



    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
