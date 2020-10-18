using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMotion : MonoBehaviour
{
    float timer = 0;
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        transform.Rotate(Vector3.up * 1);

        if (timer < 1)
        {
            transform.Translate(Vector3.up * Time.deltaTime);
        }
        else if (timer > 1 && timer < 2)
        {
            transform.Translate(-Vector3.up * Time.deltaTime);
        }
        else
            timer = 0;
    }
}
