using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckClear : MonoBehaviour
{
    public bool isClear = false;
    public bool stopPtcl = false;
    private bool playOnce = true;
    private void Update()
    {
        if (stopPtcl && playOnce)
        {
            StopLoop();
            playOnce = false;
        }
    }
    private void StopLoop()
    {
        int childrenCnt = gameObject.transform.childCount;
        ParticleSystem eft = gameObject.GetComponent<ParticleSystem>();

        var parentMain = eft.main;
        parentMain.loop = false;

        GameObject child;
        for (int i = 0; i < childrenCnt; i++)
        {
            child = gameObject.transform.GetChild(i).gameObject;
            eft = child.GetComponent<ParticleSystem>();
            var childMain = eft.main;
            childMain.loop = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag.Equals("Player"))
        {
            isClear = true;
        }
    }
}