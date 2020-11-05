using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage1_UI : MonoBehaviour
{
    public GameObject ClearCircle;
    public GameObject ClearUI;
    public Text sideText;

    private void Update()
    {
        ShowClearUI();
    }

    private void ShowClearUI()
    {
        if(!ClearUI.activeSelf && ClearCircle.GetComponent<CheckClear>().isClear)
        {
            ClearUI.SetActive(true);
        }
    }
}