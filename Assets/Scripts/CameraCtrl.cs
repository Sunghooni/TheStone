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
        this.transform.position = new Vector3(pos.x, pos.y + 3.2f, pos.z - 3.5f);
    }
}
