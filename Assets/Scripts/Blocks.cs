using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public Vector3 originPos = Vector3.zero;
    public Vector3 toPos = Vector3.zero;

    public bool canGo = true;
    public bool stopMove = false;

    public void Move()
    {
        if (this.transform.tag == "Moving" && canGo)
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
            if (stopMove && timer >= 2.1f)
            {
                this.transform.tag = "Fixed";
                break;
            }
            else
                timer += Time.deltaTime;

            if (timer <= 2.1f)
                this.transform.position = Vector3.Lerp(originPos, toPos, timer/2);
            if (timer >= 3.1f)
                this.transform.position = Vector3.Lerp(toPos, originPos, (timer - 3.1f)/2);

            if (timer > 5.2f)
            {
                this.transform.tag = "Ready";
                canGo = true;
                break;
            }
            yield return null;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        GameObject parent = other.transform.gameObject;

        if (other.transform.parent)
            parent = parent.transform.parent.gameObject;

        if (parent.tag == "Moving" || parent.tag == "Fixed")
        {
            stopMove = true;
            Debug.Log("Hit");
        }
    }
}