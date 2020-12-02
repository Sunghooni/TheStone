using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCtrl : MonoBehaviour
{
    public GameObject MainUI;
    public GameObject StageSelectUI;

    private string[] stageInfo = new string[]
    {
        "Tutorial", "Stage1", "Stage2", "Stage3"
    };

    public void PlayBtnOnclick()
    {
        Debug.Log("PlayBtn");
        LoadingScene.LoadScene(stageInfo[SaveData.Get_SelectedStage()]);
    }

    public void StageBtnOnclick()
    {
        Debug.Log("StageBtn");
        MainUI.SetActive(false);
        StageSelectUI.SetActive(true);
    }

    public void OptionBtnOnclick()
    {
        Debug.Log("OptionBtn");
    }

    public void HomeBtnOnclick()
    {
        Debug.Log("HomeBtn");
        LoadingScene.LoadScene("Main");
    }
}
