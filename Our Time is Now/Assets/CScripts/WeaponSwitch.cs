using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject Sword;
    public GameObject Bow;
    public bool TRUE;
    public bool FALSE;

    private void Start()
    {
        TRUE = true;
        FALSE = false;

        Sword.active = TRUE;
        Bow.active = FALSE;
    }

    private void Update()
    {
        Sword.active = TRUE;
        Bow.active = FALSE;

        if(SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Level1") || SceneManager.GetActiveScene() !=  SceneManager.GetSceneByName("Boss Fight"))
        {
            if (Input.GetMouseButtonDown(1))
            {
                TRUE = !TRUE;
                FALSE = !FALSE;
            }
        }
    }
}
