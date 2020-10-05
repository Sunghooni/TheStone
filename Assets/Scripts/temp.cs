using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    Vector3 originPos;
    Vector3 toPos;

    private void Awake()
    {
        originPos = this.transform.position;
        toPos = new Vector3(originPos.x, originPos.y + 3, originPos.z);
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.H))
            StartCoroutine(MoveUp());
        if (this.transform.position.y < originPos.y)
            this.transform.position = new Vector3(0, originPos.y, 0);
    }

    IEnumerator MoveUp()
    {
        float timer = 0;
        while(true)
        {
            timer += Time.deltaTime;
            this.transform.position = Vector3.Lerp(originPos, toPos, timer);
            if (timer >= 1)
                break;
            yield return null;
        }
    }
}
