using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    public GameObject[] blocks;
    public Text[] texts;
    public GameObject[] arrows;
    public ParticleSystem teleportEft;
    public GameObject homeBtn;
    public void UI_1()
    {
        texts[0].text = "press a,d to rotate";
        texts[1].text = "look behind";
    }
    public void UI_2()
    {
        texts[0].text = "press w,s to move";
        texts[1].text = "go forward";
    }
    public void UI_3()
    {
        if (blocks[0].GetComponent<Block>().blockState == Block.State.Ready)
            arrows[0].SetActive(true);
        
        texts[0].text = "click this block to act";
        texts[1].text = "";

        if(blocks[0].GetComponent<Block>().blockState == Block.State.Moving)
        {
            arrows[0].SetActive(false);
            Debug.Log("SetFalse");
        }
    }
    public void UI_4()
    {
        texts[0].text = "go and turn around";
    }
    public void UI_5()
    {
        if(blocks[1].GetComponent<Block>().blockState == Block.State.Ready)
        {
            arrows[1].SetActive(true);
            arrows[2].SetActive(true);
        }
        texts[0].text = "click both blocks";
        texts[1].text = "collide block is fixed";

        if(blocks[1].GetComponent<Block>().blockState == Block.State.Moving &&
            blocks[2].GetComponent<Block>().blockState == Block.State.Moving)
        {
            arrows[1].SetActive(false);
            arrows[2].SetActive(false);
        }
        else if(blocks[1].GetComponent<Block>().blockState == Block.State.Fixed)
        {
            arrows[3].SetActive(true);
            texts[0].text = "Click Fixed Block";
            texts[1].text = "";
            if(teleportEft.isPlaying)
            {
                arrows[3].SetActive(false);
            }
        }
    }
    public void UI_6()
    {
        texts[0].text = "you can teleport to fixed block";
        texts[1].text = "keep going!";
    }
    public void UI_7()
    {
        texts[0].text = "go to the exit!";
        texts[1].text = "";
    }
    public void UI_8()
    {
        texts[0].text = "";
        texts[2].text = "TUTORIAL CLEAR!";
        texts[3].text = "TUTORIAL CLEAR!";
        homeBtn.SetActive(true);
    }
}