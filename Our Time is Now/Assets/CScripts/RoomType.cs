using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomType : MonoBehaviour
{
    // Start is called before the first frame update

    public int type;

    public void RoomDestruction()
    {
        Destroy(gameObject);
    }

}
