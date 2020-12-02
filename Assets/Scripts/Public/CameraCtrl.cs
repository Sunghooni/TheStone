using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public GameObject Player;

    Vector3 dir;
    private float dist = 0f;
    private float width = -4f;
    private float height = 3.5f;
    private float height_fix = 1f;

    private void Awake()
    {
        height -= height_fix;
        dist = Mathf.Sqrt(width * width + height * height);
        dir = new Vector3(0, height, width).normalized;
    }
    
    private void FixedUpdate()
    {
        Vector3 ray_origin = Player.transform.position + Vector3.up * height_fix;
        Vector3 ray_target = Vector3.up * height + Player.transform.forward * width;
        RaycastHit hitInfo;
        
        if (Physics.Raycast(ray_origin, ray_target, out hitInfo, dist))
        {
            gameObject.transform.position = hitInfo.point;
        }
        else
        {
            Vector3 cameranPos = ray_origin + ray_target;
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, cameranPos, Time.deltaTime * 2f);
        }
    }
}