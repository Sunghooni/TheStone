using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    //Block 관리 or Return
    public GameObject[] Blocks;

    public Block GetBlockScript(int blockNum)
    {
        return Blocks[blockNum].GetComponent<Block>();
    }

    public string GetBlockState(int i)
    {
        string blockState = Blocks[i].GetComponent<Block>().blockState.ToString();
        return blockState;
    }

    public void SetblockState(int blockNum, string stateValue)
    {
        Blocks[blockNum].GetComponent<Block>().blockState = (Block.State) Enum.Parse(typeof(Block.State), stateValue.ToString());
    }
}