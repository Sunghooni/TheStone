using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAction : MonoBehaviour
{
    public GameObject[] blocks;
    public GameObject backBlock;
    public GameObject player;
    WizardCtrl wizardCtrl;
    public int partCnt = 1;

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
            case 4:
                Part4();
                break;
            case 5:
                Part5();
                break;
            case 6:
                Part6();
                break;
            case 7:
                Part7();
                break;
        }
    }

    void Part1()
    {
        if(player.transform.eulerAngles.y > 179 && player.transform.eulerAngles.y < 181)
        {
            Debug.Log("Part1 Clear");
            partCnt = 2;
        }
    }

    void Part2()
    {
        wizardCtrl.rotSpeed = 0;
        wizardCtrl.moveSpeed = 5;
        if(player.transform.position.z < -5.8f)
        {
            Debug.Log("Part2 Clear");
            partCnt = 3;
        }
    }

    void Part3()
    {
        wizardCtrl.rotSpeed = 0;
        wizardCtrl.moveSpeed = 0;

        if (blocks[0].tag.Equals("Untagged"))
        {
            blocks[0].tag = "Ready";
        }
        else if (blocks[0].tag.Equals("Staying"))
        {
            Debug.Log("Part3 Clear");
            blocks[0].GetComponent<Block2>().freeze = true;
            partCnt = 4;
        }
    }

    void Part4()
    {
        backBlock.SetActive(true);

        if(player.transform.position.z > -9)
        {
            wizardCtrl.moveSpeed = 5;
            wizardCtrl.rotSpeed = 0;
        }
        else if(!blocks[0].tag.Equals("Moving"))
        {
            wizardCtrl.moveSpeed = 0;
            wizardCtrl.rotSpeed = 2;
            blocks[0].GetComponent<Block2>().freeze = false;

            if (player.transform.eulerAngles.y < 2 && player.transform.eulerAngles.y >= 0)
            {
                Debug.Log("Part4 Clear");
                backBlock.SetActive(false);
                partCnt = 5;
            }
        }
    }

    void Part5()
    {
        wizardCtrl.moveSpeed = 0;
        wizardCtrl.rotSpeed = 0;

        if(blocks[1].tag.Equals("Untagged"))
        {
            blocks[1].tag = "Ready";
            blocks[2].tag = "Ready";
            blocks[1].GetComponent<Block1>().freeze = true;
            blocks[2].GetComponent<Block2>().freeze = true;
        }
        else if(blocks[1].tag.Equals("Moving") && blocks[2].tag.Equals("Moving"))
        {
            blocks[1].GetComponent<Block1>().freeze = false;
            blocks[2].GetComponent<Block2>().freeze = false;
        }
        else if(blocks[1].tag.Equals("Fixed"))
        {
            blocks[2].tag = "Untagged";
            if (player.transform.position.z == 0)
            {
                Debug.Log("Part5 Clear");
                partCnt = 6;
            }
        }
    }

    void Part6()
    {
        wizardCtrl.moveSpeed = 0;
        wizardCtrl.rotSpeed = 0;
        backBlock.SetActive(true);

        if(blocks[3].tag.Equals("Untagged"))
        {
            blocks[3].tag = "Ready";
        }
        else if(blocks[3].tag.Equals("Fixed"))
        {
            blocks[3].tag = "Untagged";
            Debug.Log("Part6 Clear");
            partCnt = 7;
        }
    }

    void Part7()
    {
        wizardCtrl.moveSpeed = 5;
        wizardCtrl.rotSpeed = 0;
        
        if(player.transform.position.z >= 12)
        {
            Debug.Log("Tutorial Finished");
            partCnt = 0;
        }
    }
}