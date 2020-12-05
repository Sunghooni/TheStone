using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Vector3 ShakePos = Vector3.zero;
    public bool stopShake = false;

    private void Awake()
    {
        StartCoroutine("Shaking");
    }

    IEnumerator Shaking()
    {
        while(!stopShake)
        {
            Vector3 randomPos;
            randomPos = Random.insideUnitSphere;

            ShakePos = randomPos;
            yield return new WaitForSeconds(0.05f);
        }

        ShakePos = Vector3.zero;
    }
}
