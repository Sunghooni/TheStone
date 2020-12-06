using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapseTrigger : MonoBehaviour
{
    public bool startCollapse = false;
    public int num;

    private bool playOnce = true;
    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = GameObject.FindWithTag("AudioManager").GetComponent<SoundManager>();
    }

    private void Update()
    {
        if (startCollapse && playOnce)
            StartCoroutine("RotatePiller");
    }

    IEnumerator RotatePiller()
    {
        soundManager.PlaySound(gameObject, "Collapse" + num);
        playOnce = false;

        while (true)
        {
            if (gameObject.transform.eulerAngles.z >= 45)
                yield return null;
            else
                transform.Rotate(Vector3.forward * 20 * Time.deltaTime);

            yield return new WaitForFixedUpdate();
        }
    }
}
