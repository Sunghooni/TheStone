using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCtrl : MonoBehaviour
{
    WizardCtrl wizardCtrl;
    TutorialScene tutorialScene;

    public GameObject[] blocks;
    public GameObject[] blockStates;
    public GameObject backBlock;
    public GameObject player;

    void Awake()
    {
        wizardCtrl = player.GetComponent<WizardCtrl>();
        tutorialScene = gameObject.GetComponent<TutorialScene>();
        wizardCtrl.moveSpeed = 0;

        foreach(GameObject obj in blocks)
        {
            obj.GetComponent<Block>().blockState = Block.State.Unmovable;
        }
    }

    public void Part1()
    {
        if(player.transform.eulerAngles.y > 178 && player.transform.eulerAngles.y < 182)
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
        var blockState = blocks[0].GetComponent<Block>().blockState;
        wizardCtrl.rotSpeed = 0;
        wizardCtrl.moveSpeed = 0;

        if (blockState == Block.State.Unmovable)
        {
            blocks[0].GetComponent<Block>().blockState = Block.State.Ready;
        }
        else if (blockState == Block.State.Staying)
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
        else if(!(blocks[0].GetComponent<Block>().blockState == Block.State.Moving))
        {
            wizardCtrl.moveSpeed = 0;
            wizardCtrl.rotSpeed = 2;
            blocks[0].GetComponent<Block>().freeze = false;

            if (player.transform.eulerAngles.y < 2 && player.transform.eulerAngles.y >= -2)
            {
                Debug.Log("Part4 Clear");
                backBlock.SetActive(false);
                tutorialScene.partCnt = 5;
            }
        }
    }

    public void Part5()
    {
        player.transform.eulerAngles = new Vector3(0, 0, 0);
        wizardCtrl.moveSpeed = 0;
        wizardCtrl.rotSpeed = 0;

        var block1_State = blocks[1].GetComponent<Block>().blockState;
        var block2_State = blocks[2].GetComponent<Block>().blockState;

        if (block1_State == Block.State.Unmovable)
        {
            blocks[1].GetComponent<Block>().blockState = Block.State.Ready;
            blocks[2].GetComponent<Block>().blockState = Block.State.Ready;
            blocks[1].GetComponent<Block>().freeze = true;
            blocks[2].GetComponent<Block>().freeze = true;
        }
        else if(block1_State == Block.State.Moving && block2_State == Block.State.Moving)
        {
            blocks[1].GetComponent<Block>().freeze = false;
            blocks[2].GetComponent<Block>().freeze = false;
        }
        else if(block1_State == Block.State.Fixed)
        {
            blocks[2].GetComponent<Block>().blockState = Block.State.Unmovable;
            if (player.transform.position.z == 0)
            {
                Debug.Log("Part5 Clear");
                tutorialScene.partCnt = 6;
            }
        }
    }

    public void Part6()
    {
        var block3_State = blocks[3].GetComponent<Block>().blockState;

        wizardCtrl.moveSpeed = 0;
        wizardCtrl.rotSpeed = 0;
        backBlock.SetActive(true);

        if(block3_State == Block.State.Unmovable)
        {
            blocks[3].GetComponent<Block>().blockState = Block.State.Ready;
        }
        else if(block3_State == Block.State.Fixed)
        {
            Debug.Log("Part6 Clear");
            blocks[3].GetComponent<Block>().blockState = Block.State.Unmovable;
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

    public void Part8()
    {
        wizardCtrl.moveSpeed = 0;
        wizardCtrl.rotSpeed = 0;
    }
}