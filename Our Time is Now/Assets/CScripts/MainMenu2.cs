using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu2 : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject levelSelect;
    //public GameObject optionsMenu;

    private void Start()
    {
        mainMenu.active = true;
        levelSelect.active = false;
        //optionsMenu.active = false;
    }

    public void Options()
    {
        mainMenu.active = false;
        //optionsMenu.active = true;

    }

    public void LevelSelect()
    {
        mainMenu.active = false;
        levelSelect.active = true;
        
    }

    public void Back()
    {
        mainMenu.active = true;
        levelSelect.active = false;
        //optionsMenu.active = false;
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void Level1()
    {
        SceneManager.LoadScene(2);
    }

    public void Level2()
    {
        SceneManager.LoadScene(4);
    }

    public void Level3()
    {
        SceneManager.LoadScene(7);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
