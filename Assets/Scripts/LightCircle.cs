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
                circles[0].SetActive(false);
                circles[1].SetActive(true);
                break;
            case 4:
                if (player.transform.position.z <= -9)
                    circles[1].SetActive(false);
                break;
            case 6:
                circles[2].SetActive(true);
                break;
            case 8:
                circles[2].SetActive(false);
                break;
        }
    }
}
