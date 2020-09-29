using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    
    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.H))
            StartCoroutine(MoveUp());
    }

    IEnumerator MoveUp()
    {
        while(true)
        {
            transform.Translate(Vector3.up * 3 * Time.deltaTime);
            yield return null;
        }
    }
}
