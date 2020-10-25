using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotBlockCtrl : MonoBehaviour
{
    public GameObject[] RotBlocks;
    public GameObject[] TrigggerBlocks;
    float timer = 0;

    void CheckTrigger()
    {
        for(int i = 0; i < TrigggerBlocks.Length; i++)
        {
            if (RotBlocks[i].tag != "Fixed")
                break;
        }
    }
}
