using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCtrl : MonoBehaviour
{
    BlockManager blockManager;
    WizardCtrl wizardCtrl;
    TutorialScene tutorialScene;
    SoundManager soundManager;

    public GameObject blockManagerObj;
    public GameObject backBlock;
    public GameObject player;

    private bool playOnce = false;

    void Awake()
    {
        blockManager = blockManagerObj.GetComponent<BlockManager>();
        wizardCtrl = player.GetComponent<WizardCtrl>();
        tutorialScene = gameObject.GetComponent<TutorialScene>();
        soundManager = GameObject.FindWithTag("AudioManager").GetComponent<SoundManager>();

        for (int i = 0; i < blockManager.Blocks.Length; i++)
        {
            blockManager.SetblockState(i, "Unmovable");
        }
    }

    public void Part1()
    {
        wizardCtrl.moveSpeed = 0;
        if (player.transform.eulerAngles.y > 178 && player.transform.eulerAngles.y < 182)
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

        if (blockManager.GetBlockState(0).Equals("Unmovable"))
        {
            blockManager.SetblockState(0, "Ready");
        }
        else if (blockManager.GetBlockState(0).Equals("Staying"))
        {
            Debug.Log("Part3 Clear");
            blockManager.GetBlockScript(0).freeze = true;
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
        else if(!blockManager.GetBlockState(0).Equals("Moving"))
        {
            wizardCtrl.moveSpeed = 0;
            wizardCtrl.rotSpeed = 2;
            blockManager.GetBlockScript(0).freeze = false;

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

        if (blockManager.GetBlockState(1).Equals("Unmovable"))
        {
            blockManager.SetblockState(1, "Ready");
            blockManager.SetblockState(2, "Ready");
            blockManager.GetBlockScript(1).freeze = true;
            blockManager.GetBlockScript(2).freeze = true;
        }
        else if(blockManager.GetBlockState(1).Equals("Moving") && blockManager.GetBlockState(2).Equals("Moving"))
        {
            blockManager.GetBlockScript(1).freeze = false;
            blockManager.GetBlockScript(2).freeze = false;
        }
        else if(blockManager.GetBlockState(1).Equals("Fixed"))
        {
            blockManager.SetblockState(2, "Unmovable");
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

        if(blockManager.GetBlockState(3).Equals("Unmovable"))
        {
            blockManager.SetblockState(3, "Ready");
        }
        else if(blockManager.GetBlockState(3).Equals("Fixed"))
        {
            Debug.Log("Part6 Clear");
            blockManager.SetblockState(3, "Unmovable");
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

        if(!playOnce)
        {
            soundManager.PlaySound(gameObject, "FinishBell");
            playOnce = true;
        }
    }
}