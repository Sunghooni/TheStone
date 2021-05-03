using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public GameObject Player;

    private float dist = 0f;
    private float height = 3.5f;
    private readonly float width = -4f;
    private readonly float height_fix = 1f;

    private void Awake()
    {
        height -= height_fix;
        dist = Mathf.Sqrt(width * width + height * height);
    }
    
    private void FixedUpdate()
    {
        Vector3 ray_origin = Player.transform.position + Vector3.up * height_fix;
        Vector3 ray_target = Vector3.up * height + Player.transform.forward * width;

        float heighRayLength = 2f;
        float downHeight = -1.5f;
        float moveBackSpeed = 2f * Time.deltaTime;

        if (Physics.Raycast(ray_origin, Vector3.up, heighRayLength)) //천장이 있을 경우
        {
            ray_target += Vector3.up * downHeight;
        }

        if (Physics.Raycast(ray_origin, ray_target, out RaycastHit hitInfo, dist)) //장애물이 있을 경우
        {
            Vector3 cameraPos = hitInfo.point;

            if (cameraPos.y > ray_target.y)
            {
                cameraPos.y = ray_target.y;
            }

            gameObject.transform.position = hitInfo.point;
        }
        else
        {
            Vector3 nowPosition = gameObject.transform.position;
            Vector3 originalPosition = ray_origin + ray_target;

            gameObject.transform.position = Vector3.Lerp(nowPosition, originalPosition, moveBackSpeed);
        }
    }
}