using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoomSpawn : MonoBehaviour
{

    public LayerMask isThereRoom;
    public LevelGeneration levelGen;

    // Update is called once per frame
    void Update()
    {

        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, isThereRoom);
        if (roomDetection == null && levelGen.stopGeneration == true)
        {
            int rand = Random.Range(0, levelGen.rooms.Length);
            Instantiate(levelGen.rooms[rand], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
