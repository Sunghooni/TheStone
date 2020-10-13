﻿using System.Collections;
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

            if (timer <= 1.1f)
                this.transform.position = Vector3.Lerp(originPos, toPos, timer);
            else if (timer >= 2.2f)
                this.transform.position = Vector3.Lerp(toPos, originPos, timer - 2.2f);

            if (timer > 3.3f)
            {
                this.transform.tag = "Ready";
                canGo = true;
                break;
            }
            yield return new WaitForFixedUpdate();
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