using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage1_UI : MonoBehaviour
{
    public GameObject ClearCircle;
    public GameObject ClearUI;
    public GameObject Part1_Circle;
    public Text sideText;

    private void Update()
    {
        ShowClearUI();
        ClearPart1();
    }

    private void ClearPart1()
    {
        if(Part1_Circle.GetComponent<CheckClear>().isClear)
        {
            Part1_Circle.GetComponent<CheckClear>().stopPtcl = true;
            sideText.text = "Press wall to collapse";
        }
    }

    private void ShowClearUI()
    {
        if(!ClearUI.activeSelf && ClearCircle.GetComponent<CheckClear>().isClear)
        {
            ClearUI.SetActive(true);
        }
    }
}