using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapseCtrl : MonoBehaviour
{
    public CollapseTrigger[] triggers;
    private int triggerCnt = 0;
    private bool start = false;
    private bool playOnce = false;

    private void Update()
    {
        if(start && !playOnce)
        {
            playOnce = true;
            StartCollapse();
        }
    }

    private void StartCollapse()
    {
        for(int i = 0; i < 3; i++)
        {
            Invoke("TriggerOn", i);
        }
    }

    private void TriggerOn()
    {
        triggers[triggerCnt].startCollapse = true;
        triggerCnt++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag.Equals("Player"))
        {
            start = true;
        }
    }
}
