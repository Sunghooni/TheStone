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
        toPos += transform.right * -3;
        Debug.Log(toPos.x + " " + toPos.y + " " + toPos.z);
    }

    private void Update()
    {
        CollideCheck();
    }

    void FixedUpdate()
    {
        if(this.transform.tag == "Moving" && canGo)
        {
            StartCoroutine(Moving());
            canGo = false;
        }
        Debug.DrawRay(this.transform.position, -transform.right, Color.red, 1.6f);
    }

    IEnumerator Moving()
    {
        float timer = 0;

        while(true)
        {
            if (this.transform.tag == "Fixed")
                break;
            else
                timer += Time.deltaTime;

            if (timer <= 1f)
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

    void CollideCheck()
    {
        if(Physics.Raycast(this.transform.position, -transform.right, out hit, 1.55f))
        {
            if(hit.transform.tag == "Moving" || hit.transform.tag == "Ready")
            {
                this.transform.tag = "Fixed";
                hit.transform.tag = "Fixed";
            }
        }
    }
}
