using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public Vector3 originalPos;
    public Vector3 toPos;
    bool canGo = true;
    bool holdPos = false;

    void Start()
    {
        originalPos = this.transform.position;
        toPos = new Vector3(originalPos.x - 3.3f, originalPos.y, originalPos.z);
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
            timer += Time.deltaTime;
            if(timer <= 1f)
            {
                this.transform.position = Vector3.Slerp(originalPos, toPos, timer);
            }
            else if (timer > 1f)
            {
                this.transform.position = Vector3.Slerp(toPos, originalPos, timer - 1f);
            }
            if (timer > 2f)
            {
                this.transform.tag = "Ready";
                canGo = true;
                break;
            }
            if(holdPos)
            {
                this.transform.tag = "Fixed";
                break;
            }
            yield return null;
        }
    }
    //rigidbody없이는 사용 불가!
    /*
    public void OnCollisionEnter(Collision collision) 
    {
        if(collision.transform.tag == "Moving" || collision.transform.tag == "Ready")
        {
            Debug.Log("Collide");
            holdPos = true;
        }
    }
    */
}
