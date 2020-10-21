using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour
{
    public void HomeBtnOnclick()
    {
        Debug.Log("HomeBtn");
        LoadingScene.LoadScene("Main");
    }
}
