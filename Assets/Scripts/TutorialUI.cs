﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    public Canvas tutorialUI;
    public GameObject[] blocks;
    public Text[] texts;
    public GameObject[] arrows;
    public ParticleSystem teleportEft;

    public void UI_1()
    {
        texts[0].text = "press a,d to rotate";
    }
    public void UI_2()
    {
        texts[0].text = "press w,s to move";
    }
    public void UI_3()
    {
        if(blocks[0].tag.Equals("Untagged"))
            arrows[0].SetActive(true);

        texts[0].text = "click this block to act";

        if(blocks[0].transform.tag.Equals("Moving"))
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
        if(blocks[1].tag.Equals("Ready"))
        {
            arrows[1].SetActive(true);
            arrows[2].SetActive(true);
        }
        texts[0].text = "click both blocks";
        texts[1].text = "collide block is fixed";

        if(blocks[1].tag.Equals("Moving") && blocks[2].tag.Equals("Moving"))
        {
            arrows[1].SetActive(false);
            arrows[2].SetActive(false);
        }
        else if(blocks[1].tag.Equals("Fixed"))
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
        texts[0].text = "tutorial clear!";
        //texts[2].text = "tutorial clear!";
    }
}