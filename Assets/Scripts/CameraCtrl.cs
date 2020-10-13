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
        var cameraPos = this.transform.position;
        var playerPos = player.transform.position;
        Vector3 rayPos = new Vector3(playerPos.x, playerPos.y + 1, playerPos.z);
        //상하 자동 조절
        if (Physics.Raycast(rayPos, Vector3.up, out hit, 2.5f))
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(cameraPos.x, 2.5f, cameraPos.z), Time.deltaTime);
        else
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(cameraPos.x, 3.5f, cameraPos.z), Time.deltaTime);

        Debug.DrawRay(rayPos, Vector3.up * 2.5f, Color.red, 0, false);
        Debug.DrawRay(this.transform.position, transform.right * 3.5f, Color.red, 0, false);
    }
}