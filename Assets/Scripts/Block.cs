using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Block : MonoBehaviour
{
    public Vector3 originPos = Vector3.zero;
    public Vector3 toPos = Vector3.zero;

    public float MoveDistance = 0;
    public bool canGo = true;
    public bool stopMove = false;
    public bool freeze = false;

    void Awake()
    {
        originPos = this.transform.position;
        toPos = originPos + transform.right * -MoveDistance;
    }

    private void FixedUpdate()
    {
        Move();
    }

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
            if(!freeze)
                timer += Time.deltaTime;

            if (stopMove && timer >= 2.1f)
            {
                gameObject.tag = "Fixed";
                break;
            }

            if (timer <= 2.1f)
            {
                gameObject.tag = "Moving";
                this.transform.position = Vector3.Lerp(originPos, toPos, timer / 2);
            }
            else if (timer > 2.1f && timer < 3.2f)
            {
                gameObject.tag = "Staying";
            }
            else if (timer >= 3.2f)
            {
                gameObject.tag = "Backing";
                this.transform.position = Vector3.Lerp(toPos, originPos, (timer - 3.2f) / 2);
            }

            if (timer > 5.3f)
            {
                gameObject.tag = "Ready";
                canGo = true;
                break;
            }
            yield return new WaitForFixedUpdate();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        GameObject triggerObj = other.transform.gameObject;

        if (other.transform.parent)
            triggerObj = other.transform.parent.gameObject;

        if (triggerObj.tag == "Moving" || triggerObj.tag == "Fixed" || triggerObj.tag == "Staying")
        {
            stopMove = true;
            Debug.Log("Hit");
        }
    }
}