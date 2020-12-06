using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCheck_2 : MonoBehaviour
{
    public GameObject Player;
    public GameObject ClearPanel;
    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = GameObject.FindWithTag("AudioManager").GetComponent<SoundManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag.Equals("Player"))
        {
            Vector3 ClearPos = gameObject.transform.position;
            ClearPos.y = -2.25f;
            other.transform.position = ClearPos;
            other.transform.eulerAngles = new Vector3(0 , 90, 0);
            ClearPanel.SetActive(true);
            Player.GetComponent<WizardCtrl>().moveSpeed = 0;
            Player.GetComponent<WizardCtrl>().rotSpeed = 0;
            soundManager.PlaySound(gameObject, "FinishBell");
        }
    }
}
