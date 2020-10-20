using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    public void PlayBtnOnclick()
    {
        Debug.Log("PlayBtn");
        LoadingScene.LoadScene("Tutorial");
        //SceneManager.LoadScene("Tutorial");
    }

    public void StageBtnOnclick()
    {
        Debug.Log("StageBtn");
    }

    public void OptionBtnOnclick()
    {
        Debug.Log("OptionBtn");
    }
}
