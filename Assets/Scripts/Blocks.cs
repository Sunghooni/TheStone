using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public Vector3 originPos;
    public Vector3 toPos;

    private bool canGo = true;
    private RaycastHit hit;

    void Awake()
    {
        originPos = this.transform.position;
        toPos = originPos;
        toPos += transform.right * -3f;
    }

    void FixedUpdate()
    {
        if(this.transform.tag == "Moving" && canGo)
        {
            StartCoroutine(Moving());
            canGo = false;
        }
    }

    IEnumerator Moving()
    {
        float timer = 0;

        while(true)
        {
            if (this.transform.tag == "Fixed" && timer >= 1.1f)
                break;
            else
                timer += Time.deltaTime;

            if (timer <= 1.1f)
                this.transform.position = Vector3.Lerp(originPos, toPos, timer);
            if (timer >= 1.5f)
                this.transform.position = Vector3.Lerp(toPos, originPos, timer - 1.5f);

            if (timer > 2.5f)
            {
                this.transform.tag = "Ready";
                canGo = true;
                break;
            }
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Untagged")
        {
            this.transform.tag = "Fixed";
            other.transform.tag = "Fixed";
            Debug.Log("Hit");
        }
    }
}