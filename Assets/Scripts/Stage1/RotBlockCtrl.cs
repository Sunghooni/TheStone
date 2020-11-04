using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotBlockCtrl : MonoBehaviour
{

    public GameObject Player;
    public GameObject[] RotBlocks;
    public GameObject[] TriggerBlocks;
    public GameObject[] Circles;

    private int triggerCnt = 5;

    private void Update()
    {
        CheckTrigger();
        CircleCtrl();
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
            if(!Circles[0].activeSelf)
                Circles[0].SetActive(true);
        }
    }

    void CircleCtrl()
    {
        if (Circles[0].GetComponent<CheckClear>().isClear)
        {
            if(triggerCnt == 5)
            {
                RotStart();
                Player.GetComponent<WizardCtrl>().moveSpeed = 0;
            }
        }
        if(RotBlocks[0].transform.eulerAngles.z > 89)
        {
            Circles[0].GetComponent<CheckClear>().stopPtcl = true;
            Player.GetComponent<WizardCtrl>().moveSpeed = 5;
            Circles[1].SetActive(true);
        }
        if (Circles[1].activeSelf && Circles[1].GetComponent<CheckClear>().isClear)
        {
            Player.GetComponent<WizardCtrl>().moveSpeed = 0;
            Player.GetComponent<WizardCtrl>().rotSpeed = 0;
            Circles[1].GetComponent<CheckClear>().stopPtcl = true;
        }
    }

    void RotStart()
    {
        for (float i = 0; i < TriggerBlocks.Length; i++)
        {
            Invoke("RotBlock", i/2);
        }
    }

    void RotBlock()
    {
        RotBlocks[triggerCnt--].GetComponent<RotBlock>().startRot = true;
    }
}
