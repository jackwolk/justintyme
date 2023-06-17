using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject VCam;
    public PlayerInRange isInRange;

    private void Update()
    {
        if(isInRange.canSeePlayer == true)
        {
            VCam.SetActive(true);
        }
        else
        {
            VCam.SetActive(false);
        }
        
    }

}
