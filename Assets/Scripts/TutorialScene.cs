using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScene : MonoBehaviour
{
    TutorialCtrl tutorialCtrl;
    TutorialUI tutorialUI;
    LightCircle lightCircle;

    private void Awake()
    {
        tutorialCtrl = gameObject.GetComponent<TutorialCtrl>();
        tutorialUI = gameObject.GetComponent<TutorialUI>();
        lightCircle = gameObject.GetComponent<LightCircle>();
    }

    private void Update()
    {
        int part = tutorialCtrl.partCnt;
        lightCircle.CircleCtrl(part);

        switch (part)
        {
            case 1:
                tutorialCtrl.Part1();
                tutorialUI.UI_1();
                break;
            case 2:
                tutorialCtrl.Part2();
                tutorialUI.UI_2();
                break;
            case 3:
                tutorialCtrl.Part3();
                tutorialUI.UI_3();
                break;
            case 4:
                tutorialCtrl.Part4();
                tutorialUI.UI_4();
                break;
            case 5:
                tutorialCtrl.Part5();
                tutorialUI.UI_5();
                break;
            case 6:
                tutorialCtrl.Part6();
                tutorialUI.UI_6();
                break;
            case 7:
                tutorialCtrl.Part7();
                tutorialUI.UI_7();
                break;
        }
    }
}
