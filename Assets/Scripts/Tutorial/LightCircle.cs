using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCircle : MonoBehaviour
{
    public GameObject[] circles;
    public GameObject player;

    public void StartPtcl(int circleCnt)
    {
        circles[circleCnt].SetActive(true);
    }

    public void StopLoop(int circleCnt)
    {
        int childrenCnt = circles[circleCnt].transform.childCount;
        ParticleSystem eft = circles[circleCnt].GetComponent<ParticleSystem>();

        if(circleCnt == 1 && player.transform.position.z > -9)
            return;

        var parentMain = eft.main;
        parentMain.loop = false;

        GameObject child;
        for (int i = 0; i < childrenCnt; i++)
        {
            child = circles[circleCnt].transform.GetChild(i).gameObject;
            eft = child.GetComponent<ParticleSystem>();
            var childMain = eft.main;
            childMain.loop = false;
        }
    }
}
