using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCtrl : MonoBehaviour
{
    WizardCtrl wizardCtrl;
    TutorialScene tutorialScene;
    public GameObject[] blocks;
    public GameObject backBlock;
    public GameObject player;

    void Awake()
    {
        wizardCtrl = player.GetComponent<WizardCtrl>();
        tutorialScene = gameObject.GetComponent<TutorialScene>();
        wizardCtrl.moveSpeed = 0;
        foreach(GameObject obj in blocks)
        {
            obj.tag = "Untagged";
        }
    }

    public void Part1()
    {
        if(player.transform.eulerAngles.y > 179 && player.transform.eulerAngles.y < 181)
        {
            Debug.Log("Part1 Clear");
            tutorialScene.partCnt = 2;
        }
    }

    public void Part2()
    {
        player.transform.eulerAngles = new Vector3(0, 180, 0);
        wizardCtrl.rotSpeed = 0;
        wizardCtrl.moveSpeed = 5;

        if(player.transform.position.z < -5.8f)
        {
            Debug.Log("Part2 Clear");
            tutorialScene.partCnt = 3;
        }
    }

    public void Part3()
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
            blocks[0].GetComponent<Block>().freeze = true;
            tutorialScene.partCnt = 4;
        }
    }

    public void Part4()
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
            blocks[0].GetComponent<Block>().freeze = false;

            if (player.transform.eulerAngles.y < 2 && player.transform.eulerAngles.y >= 0)
            {
                backBlock.SetActive(false);
                Debug.Log("Part4 Clear");
                tutorialScene.partCnt = 5;
            }
        }
    }

    public void Part5()
    {
        player.transform.eulerAngles = new Vector3(0, 0, 0);
        wizardCtrl.moveSpeed = 0;
        wizardCtrl.rotSpeed = 0;

        if(blocks[1].tag.Equals("Untagged"))
        {
            blocks[1].tag = "Ready";
            blocks[2].tag = "Ready";
            blocks[1].GetComponent<Block>().freeze = true;
            blocks[2].GetComponent<Block>().freeze = true;
        }
        else if(blocks[1].tag.Equals("Moving") && blocks[2].tag.Equals("Moving"))
        {
            blocks[1].GetComponent<Block>().freeze = false;
            blocks[2].GetComponent<Block>().freeze = false;
        }
        else if(blocks[1].tag.Equals("Fixed"))
        {
            blocks[2].tag = "Untagged";
            if (player.transform.position.z == 0)
            {
                Debug.Log("Part5 Clear");
                tutorialScene.partCnt = 6;
            }
        }
    }

    public void Part6()
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
            tutorialScene.partCnt = 7;
        }
    }

    public void Part7()
    {
        wizardCtrl.moveSpeed = 5;
        wizardCtrl.rotSpeed = 0;
        
        if(player.transform.position.z >= 15)
        {
            Debug.Log("Tutorial Finished");
            tutorialScene.partCnt = 8;
        }
    }
}