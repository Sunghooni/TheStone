using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    public Canvas tutorialUI;
    public Text[] texts;
    public string[] sentences;
    TutorialAction tutorialAct;

    private void Awake()
    {
        tutorialAct = gameObject.GetComponent<TutorialAction>();
    }

    private void Update()
    {
        switch(tutorialAct.partCnt)
        {
            case 1:
                UI_1();
                break;
        }
    }

    void UI_1()
    {
        texts[1].text = sentences[0];
    }
}
