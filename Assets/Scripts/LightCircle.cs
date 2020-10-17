using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCircle : MonoBehaviour
{
    public GameObject player;
    public GameObject[] circles;

    public void CircleCtrl(int partCnt)
    {
        switch (partCnt)
        {
            case 1:
                circles[0].SetActive(true);
                break;
            case 3:
                StopLoop(0);
                circles[1].SetActive(true);
                break;
            case 4:
                if (player.transform.position.z <= -9)
                    StopLoop(1);
                break;
            case 6:
                circles[2].SetActive(true);
                break;
            case 8:
                StopLoop(2);
                break;
        }
    }

    void StopLoop(int partCnt)
    {
        int childrenCnt = circles[partCnt].transform.childCount;
        ParticleSystem eft = circles[partCnt].GetComponent<ParticleSystem>();

        var parentMain = eft.main;
        parentMain.loop = false;

        GameObject child;
        for (int i = 0; i < childrenCnt; i++)
        {
            child = circles[partCnt].transform.GetChild(i).gameObject;
            eft = child.GetComponent<ParticleSystem>();
            var childMain = eft.main;
            childMain.loop = false;
        }
    }
}
