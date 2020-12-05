using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove_2 : MonoBehaviour
{
    public GameObject Player;
    CameraShake cameraShake;

    Vector3 dir;
    private float dist = 0f;
    private float width = -4f;
    private float height = 3.5f;
    private float height_fix = 1f;

    private void Awake()
    {
        cameraShake = gameObject.GetComponent<CameraShake>();
        height -= height_fix;
        dist = Mathf.Sqrt(width * width + height * height);
        dir = new Vector3(0, height, width).normalized;
    }

    private void FixedUpdate()
    {
        BasicMove();
    }

    private void BasicMove()
    {
        Vector3 ray_origin = Player.transform.position + Vector3.up * height_fix;
        Vector3 ray_target = Vector3.up * height + Player.transform.forward * width + cameraShake.ShakePos;
        RaycastHit hitInfo;

        if (Physics.Raycast(ray_origin, Vector3.up, 2f))
        {
            ray_target = ray_target + Vector3.up * -1.5f;
        }

        if (Physics.Raycast(ray_origin, ray_target, out hitInfo, dist))
        {
            Vector3 cameraPos = hitInfo.point;

            if (cameraPos.y > ray_target.y)
                cameraPos.y = ray_target.y;

            gameObject.transform.position = hitInfo.point;
        }
        else
        {
            Vector3 cameranPos = ray_origin + ray_target;
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, cameranPos, Time.deltaTime * 3f);
        }
    }
}