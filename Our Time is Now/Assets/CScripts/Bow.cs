using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public float delay = 3f;
    private bool attackReady;

    public GameObject arrow;

    private void Start()
    {
        attackReady = true;
    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    public void Attack()
    {

        if (attackReady == true)
        {
            Instantiate(arrow, gameObject.transform.position, gameObject.transform.rotation);
            Debug.Log("Attacking");
            attackReady = false;
            StartCoroutine(DelayAttack());
        }
        else
        {
            return;
        }
    }
    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackReady = true;
    }
}
