using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectBtn : MonoBehaviour
{
    public int stageNum;
    public GameObject MainUI;
    public GameObject StageSelectUI;

    public void StageSelect()
    {
        SaveData.Set_SelectedStage(stageNum);
        StageSelectUI.SetActive(false);
        MainUI.SetActive(true);
    }
}
