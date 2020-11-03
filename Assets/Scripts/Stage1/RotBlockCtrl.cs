using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotBlockCtrl : MonoBehaviour
{
    public GameObject[] RotBlocks;
    public GameObject[] TriggerBlocks;
    int triggerCnt = 5;

    private void Update()
    {
        CheckTrigger();
    }

    void CheckTrigger()
    {
        int cnt = 0;
        for(int i = 0; i < TriggerBlocks.Length; i++)
        {
            cnt = (TriggerBlocks[i].tag.Equals("Fixed") ? cnt + 1 : cnt);
        }
        if(cnt == TriggerBlocks.Length && triggerCnt == 5)
        {
            Debug.Log("Start");
            RotStart();
        }
    }

    void RotStart()
    {
        for(int i = 0; i < TriggerBlocks.Length; i++)
        {
            Invoke("TriggerOn", i/2);
        }
    }

    void TriggerOn()
    {
        RotBlocks[triggerCnt--].GetComponent<RotBlock>().startRot = true;
    }
}
