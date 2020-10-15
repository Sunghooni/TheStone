using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScene : MonoBehaviour
{
    public GameObject[] blocks;
    public GameObject player;
    WizardCtrl wizardCtrl;
    private int partCnt = 1;

    void Awake()
    {
        wizardCtrl = player.GetComponent<WizardCtrl>();
        wizardCtrl.moveSpeed = 0;
        foreach(GameObject obj in blocks)
        {
            obj.tag = "Untagged";
        }
    }

    private void Update()
    {
        switch(partCnt)
        {
            case 1:
                Part1();
                break;
            case 2:
                Part2();
                break;
            case 3:
                Part3();
                break;
        }
    }

    void Part1()
    {
        if(player.transform.eulerAngles.y > 179 || 
           player.transform.eulerAngles.y < -179)
        {
            Debug.Log("Part1 Clear");
            partCnt = 2;
        }
    }

    void Part2()
    {
        wizardCtrl.rotSpeed = 0;
        wizardCtrl.moveSpeed = 5;
        if(player.transform.position.z < -6)
        {
            Debug.Log("Part2 Clear");
            partCnt = 3;
        }
    }

    void Part3()
    {
        wizardCtrl.rotSpeed = 0;
        wizardCtrl.moveSpeed = 0;
        if (blocks[0].tag == "Moving")
        {
            Debug.Log("Part3 Clear");
            partCnt = 3;
        }
    }
}
