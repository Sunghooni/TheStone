using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    public Canvas tutorialUI;
    public GameObject rightBlock;
    public Text[] texts;

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
        texts[0].text = "click this block to act";
    }
    public void UI_4()
    {
        texts[0].text = "go and turn around";
    }
    public void UI_5()
    {
        texts[0].text = "click both blocks";
        if(rightBlock.tag.Equals("Fixed"))
        {
            texts[0].text = "Click Fixed Block";
        }
    }
    public void UI_6()
    {
        texts[0].text = "you can teleport to fixed block";
    }
    public void UI_7()
    {
        texts[0].text = "go to the exit!";
    }
    public void UI_8()
    {
        texts[0].text = "Tutorial Clear!";
    }
}