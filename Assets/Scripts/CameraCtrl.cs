using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public GameObject player;
    Vector3 toPos;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        var pos = this.transform.position;
        if (Physics.Raycast(player.transform.position, Vector3.up, out hit, 3.5f))
        {
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(pos.x, 1, pos.z), Time.deltaTime);
        }

        Debug.DrawRay(player.transform.position, Vector3.up * 3.5f, Color.red, 0, false);
        Debug.DrawRay(this.transform.position, transform.right * 3.5f, Color.red, 0, false);
    }
}