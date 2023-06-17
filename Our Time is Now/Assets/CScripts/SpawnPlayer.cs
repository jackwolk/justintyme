using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{

    public GameObject player;
    public GameObject invisibleFollower;
    public GameObject spawnPoint;
    public LevelGeneration levelGen;

    private bool doOnce = true;

    // Start is called before the first frame update
    void Update()
    {
        if (doOnce == true)
        {


            player.transform.position = spawnPoint.transform.position;
            invisibleFollower.transform.position = spawnPoint.transform.position;
            doOnce = false;
        }
    }
}
        // Update is called once per frame

    
