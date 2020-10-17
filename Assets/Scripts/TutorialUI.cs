using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    public Canvas tutorialUI;
    public Text[] texts;
    public string[] sentences;

    public void UI_1()
    {
        texts[0].text = sentences[0];
    }
    public void UI_2()
    {
        texts[0].text = sentences[1];
    }
    public void UI_3()
    {
        texts[0].text = sentences[2];
    }
    public void UI_4()
    {
        texts[0].text = sentences[3];
    }
    public void UI_5()
    {
        texts[0].text = sentences[4];
    }
    public void UI_6()
    {
        texts[0].text = sentences[5];
    }
    public void UI_7()
    {
        texts[0].text = sentences[6];
    }
}