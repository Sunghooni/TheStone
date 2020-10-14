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
        var cameraPos = this.transform.position;
        var playerPos = player.transform.position;
        Vector3 upDownRay = new Vector3(playerPos.x, playerPos.y + 1, playerPos.z);
        Vector3 sideRay = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);

        //상하 자동 조절
        if (Physics.Raycast(upDownRay, Vector3.up, 2.5f))
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(cameraPos.x, playerPos.y + 2.5f, cameraPos.z), Time.deltaTime);
        else
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(cameraPos.x, playerPos.y + 3.5f, cameraPos.z), Time.deltaTime);
        
        //Debug.DrawRay(upDownRay, Vector3.up * 2.5f, Color.red, 0, true);
        //Debug.DrawRay(this.transform.position, transform.right * 3.5f, Color.red, 0, true);
    }
}