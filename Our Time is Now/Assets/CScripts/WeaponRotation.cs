using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    public Camera _camera;
    public GameObject parent;
    public Vector2 CursorPosition;
    public SpriteRenderer renderer;
    public SpriteRenderer swordRenderer;
    public SpriteRenderer bowRenderer;
    public GameObject sword;
    public GameObject bow;
    public GameObject activeWeapon;



    private void Start()
    {
        if(sword.active == true)
        {
            renderer = swordRenderer;
        }
        else
        {
            renderer = bowRenderer;

        }
    }


    private void Update()
    {
        if (sword.active == true)
        {
            renderer = swordRenderer;
            activeWeapon = sword;
        }
        else
        {
            renderer = bowRenderer;
            activeWeapon = bow;
        }





        transform.position = parent.transform.position;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(
        mousePosition.x - transform.position.x,
        mousePosition.y - transform.position.y
        );

        if(mousePosition.x > transform.position.x)
        {
            renderer.flipY = true;
        }
        else
        {
            renderer.flipY = false;
        }

        transform.right = direction;
        

    }

 


}
