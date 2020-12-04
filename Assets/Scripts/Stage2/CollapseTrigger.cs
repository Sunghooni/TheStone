using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapseTrigger : MonoBehaviour
{
    public bool startCollapse = false;
    private bool playOnce = true;

    private void Update()
    {
        if (startCollapse && playOnce)
            StartCoroutine("RotatePiller");
    }
    IEnumerator RotatePiller()
    {
        playOnce = false;

        while (true)
        {
            if (gameObject.transform.eulerAngles.z >= 45)
                yield return null;
            else
                transform.Rotate(Vector3.forward * 10 * Time.deltaTime);

            yield return new WaitForFixedUpdate();
        }
    }
}
