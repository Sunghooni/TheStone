using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
            
    }

    void FixedUpdate()
    {
        var pos = player.transform.position;
        this.transform.position = new Vector3(pos.x - 5, pos.y + 5, pos.z - 5);
    }
}
