using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2_UI : MonoBehaviour
{
    public Text subText;
    public GameObject[] PartChecks;
    public int cnt = 0;

    public string[] texts = new string[3]
    {
        "World is collapsing!", "run to exit!", "You need to Block All Pillars!"
    };

    private void Awake()
    {
        SetText(texts[0]);
    }

    private void Update()
    {
        if (cnt < PartChecks.Length && PartChecks[cnt].GetComponent<Explode>().trigger)
        {
            SetText(texts[cnt + 1]);
            cnt++;
        }
    }

    private void SetText(string value)
    {
        subText.text = value;
        if(cnt == 1)
            Invoke("ResetText", 3f);
    }

    private void ResetText()
    {
        subText.text = "";
    }
}
