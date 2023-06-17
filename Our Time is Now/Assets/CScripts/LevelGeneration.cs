using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    //Level Generation

    public Transform[] startingPosition;
    public GameObject[] rooms; // 0 = LR, 1 = LRT, 2 = LRB, 3 = LRTB, 
    public GameObject[] startingRoom;
    public GameObject spawnPoint;
    private int direction;
    public float moveAmount;
    private float timeBtwRoom;
    public float startTimeBtwRoom = 0.25f;
    public float minX;
    public float maxX;
    public float minY;
    public bool stopGeneration = false;
    public LayerMask room;
    private int DownCounter = 0;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    void Start()
    {
        int randStartingPos = Random.Range(0, startingPosition.Length);
        transform.position = startingPosition[randStartingPos].position;
        Instantiate(startingRoom[0], transform.position, Quaternion.identity);
        if (randStartingPos == 0)
        {
            spawnPoint.transform.position = new Vector3(-15, 16);
        } 
        else if (randStartingPos == 1)
        {
            spawnPoint.transform.position = new Vector3(-5, 16);
        }
        else if (randStartingPos == 2)
        {
            spawnPoint.transform.position = new Vector3(5, 16);
        }
        else
        {
            spawnPoint.transform.position = new Vector3(15, 16);
        }
        direction = Random.Range(1, 5);
    }
    private void Update()
    {
        if (timeBtwRoom <= 0 && stopGeneration == false)
        {
            Move();
            timeBtwRoom = startTimeBtwRoom;
        }
        else
        {
            timeBtwRoom -= Time.deltaTime;
        }
    }

    private void Move()
    {
        if (direction == 1 || direction == 2) //Move the path right
        {
            if (transform.position.x < maxX)
            {
                DownCounter = 0;
                Vector2 newPosition = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPosition;
                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);
                direction = Random.Range(1, 6);
                if (direction == 3)
                {
                    direction = 2;
                }
                else if (direction == 4)
                {
                    direction = 5;
                }
            }
            else
            {
                direction = 5;
            }
        }
        else if (direction == 3 || direction == 4) // Move the path left
        {
            if (transform.position.x > minX)
            {
                DownCounter = 0;
                Vector2 newPosition = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPosition;
                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);
                direction = Random.Range(3, 5);
            }
            else
            {
                direction = 5;
            }
        }
        else if (direction == 5)
        {
            DownCounter++;
            if (transform.position.y > minY)
            {
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);
                if (roomDetection.GetComponent<RoomType>().type != 2 && roomDetection.GetComponent<RoomType>().type != 3 && roomDetection.GetComponent<RoomType>().type != 4)
                {
                    if (DownCounter >= 2)
                    {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();
                        Instantiate(rooms[3], transform.position, Quaternion.identity);
                    }
                    else
                    {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();
                        int randBottomRoom = Random.Range(1, 4);
                        if (randBottomRoom == 1)
                        {
                            randBottomRoom = 2;
                        }
                        Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
                    }
                }
                Vector2 newPosition = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPosition;
                int rand = Random.Range(1, 3);
                if (rand == 2)
                {
                    rand = 3;
                }
                Instantiate(rooms[rand], transform.position, Quaternion.identity);
                direction = Random.Range(1, 6);
            }
            else
            {
                stopGeneration = true;
            }
        }
    }
}
