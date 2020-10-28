using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RotBlock : MonoBehaviour
{
    Vector3 rotPoint;
    public bool startRot = false;

    void Awake()
    {
        var pos = this.transform.position;
        rotPoint = new Vector3(pos.x - 1.5f, pos.y - 1.5f, pos.z);        
    }

    private void Update()
    {
        if(startRot && this.transform.eulerAngles.z == 0)
        {
            StartCoroutine(RotMovement());
        }
    }

    IEnumerator RotMovement()
    {
        while(true)
        {
            if (this.transform.eulerAngles.z > 90)
                break;
            transform.RotateAround(rotPoint, Vector3.forward, 5 * Time.deltaTime);
            yield return new FixedUpdate();
        }
    }
}
