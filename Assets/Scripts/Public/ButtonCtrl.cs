using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCtrl : MonoBehaviour
{
    public void PlayBtnOnclick()
    {
        Debug.Log("PlayBtn");
        LoadingScene.LoadScene("Tutorial");
    }

    public void StageBtnOnclick()
    {
        Debug.Log("StageBtn");
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
