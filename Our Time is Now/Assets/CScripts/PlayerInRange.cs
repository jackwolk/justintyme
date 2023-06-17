using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRange : MonoBehaviour
{

    public bool canSeePlayer;
    private Animator _animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerMovement>(out PlayerMovement Player))
        {
            Debug.Log("Player Detected");
            canSeePlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerMovement>(out PlayerMovement Player))
        {
            Debug.Log("Player Left Range");
            canSeePlayer = false;
        }
    }

}
