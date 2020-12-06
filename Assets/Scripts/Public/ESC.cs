using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESC : MonoBehaviour
{
    public GameObject Escape;

    private void Update()
    {
        int cnt = 0;

        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            if(gameObject.transform.GetChild(i).gameObject.activeSelf)
            {
                cnt++;
            }
        }
        Debug.Log(cnt);
        if (!Escape.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && cnt == 1)
            {
                Escape.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Escape.SetActive(false);
            }
        }
    }
}
