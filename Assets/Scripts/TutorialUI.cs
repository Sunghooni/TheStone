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
                texts[1].text = sentences[0];
                break;
            case 2:
                texts[1].text = sentences[1];
                break;
            case 3:
                texts[1].text = sentences[2];
                break;
            case 4:
                texts[1].text = sentences[3];
                break;
            case 5:
                texts[1].text = sentences[4];
                break;
            case 6:
                texts[1].text = sentences[5];
                break;
            case 7:
                texts[1].text = sentences[6];
                break;
        }
    }
}
