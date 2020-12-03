using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonCtrl : MonoBehaviour
{
    public GameObject MainUI;
    public GameObject StageSelectUI;
    public GameObject OptionUI;
    public Scrollbar scrollBar;

    private string[] stageInfo = new string[]
    {
        "Tutorial", "Stage1", "Stage2", "Stage3"
    };

    public void PlayBtnOnclick()
    {
        LoadingScene.LoadScene(stageInfo[SaveData.Get_SelectedStage()]);
    }

    public void StageBtnOnclick()
    {
        MainUI.SetActive(false);
        StageSelectUI.SetActive(true);
    }

    public void OptionBtnOnclick()
    {
        StageSelectUI.SetActive(false);
        MainUI.SetActive(false);
        OptionUI.SetActive(true);
    }

    public void HomeBtnOnclick()
    {
        LoadingScene.LoadScene("Main");
    }

    public void VolumeCtrl()
    {
        Debug.Log(scrollBar.value);
        SaveData.Set_Volume(scrollBar.value);
    }

    public void Full_HD()
    {
        SettingResolution(1920, 1080);
    }

    public void HD()
    {
        SettingResolution(1280, 720);
    }

    public void BeforeButton()
    {
        StageSelectUI.SetActive(false);
        OptionUI.SetActive(false);
        MainUI.SetActive(true);
    }

    private void SettingResolution(int Row, int Col)
    {
        Screen.SetResolution(Row, Col, Screen.fullScreenMode);
    }
}
