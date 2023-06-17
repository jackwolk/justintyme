using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooCoo : MonoBehaviour
{
    public Health health;
    public GameObject homingAttack;
    public bool alreadyFired;
    void Start()
    {
        alreadyFired = false;
        health = gameObject.GetComponent<Health>();
    }
    void Update()
    {
        if(alreadyFired == false)
        {
            Shoot();
            StartCoroutine(ResetAttack());
        }
    }
    void Shoot()
    {
        Instantiate(homingAttack, gameObject.transform.position + new Vector3(1, 1, 0), Quaternion.identity);
        alreadyFired = true;
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(3);
        alreadyFired = false;
    }
}
