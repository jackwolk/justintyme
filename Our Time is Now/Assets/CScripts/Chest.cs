using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{


    Animator _animator;
    string currentAnimation;
    public PlayerInRange canSeePlayer;
    public GameObject[] itemDrops;
    bool didOnce;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        didOnce = false;
    }

    private void ChangeAnimationState(string newState)
    {
        if (newState == currentAnimation)
        {
            return;
        }

        _animator.Play(newState);
        currentAnimation = newState;

    }

    private void Update()
    {
        if(canSeePlayer.canSeePlayer == true && Input.GetKeyDown(KeyCode.E) && didOnce == false)
        {
            didOnce = true;
            ChangeAnimationState("ChestOpen");
            StartCoroutine(OpenChest()) ;
        }
    }

    IEnumerator OpenChest()
    {
        yield return new WaitForSeconds(1);

        int rand = Random.Range(0, itemDrops.Length);

        Instantiate(itemDrops[rand], gameObject.transform.position - new Vector3(0, 0.5f, 0), Quaternion.identity);

    }


}
