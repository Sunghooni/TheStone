using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RotBlock : MonoBehaviour
{
    Vector3 rotPoint;

    void Awake()
    {
        var pos = this.transform.position;
        rotPoint = new Vector3(pos.x - 1.5f, pos.y - 1.5f, pos.z);
        StartCoroutine(RotMovement());
        
    }

    void Update()
    {
        Debug.DrawRay(rotPoint, Vector3.forward * 1, Color.red, 2);
    }

    IEnumerator RotMovement()
    {
        while(true)
        {
            if (this.transform.eulerAngles.z > 90)
                break;
            transform.RotateAround(rotPoint, Vector3.forward, Time.deltaTime);
            yield return new FixedUpdate();
        }
    }
}
