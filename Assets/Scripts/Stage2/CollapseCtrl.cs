using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapseCtrl : MonoBehaviour
{
    public CollapseTrigger[] triggers;
    public GameObject Player;
    public GameObject Camera;
    public GameObject middleHead;
    public bool stopView = false;
    private int triggerCnt = 0;
    private bool start = false;
    private bool playOnce = false;
    private float originX;
    private Vector3 stayPos;

    private void Update()
    {
        if(start && !playOnce)
        {
            Player.GetComponent<WizardCtrl>().rotSpeed = 0;
            Player.transform.eulerAngles = new Vector3(0, 180, 0);
            playOnce = true;
            originX = Camera.transform.position.x;
            Camera.GetComponent<CameraMove_2>().enabled = false;
            stayPos = Camera.transform.position;

            StartCollapse();
            StartCoroutine("CameraSet");
        }
    }

    private void FixedUpdate()
    {
        if (start)
        {
            Vector3 lookPos = new Vector3(20, 90, 0);
            Camera.transform.eulerAngles = Vector3.Lerp(Camera.transform.eulerAngles, lookPos, Time.deltaTime * 3);
            Camera.transform.position = Vector3.Lerp(Camera.transform.position, stayPos, Time.deltaTime * 3);
        }
    }

    IEnumerator CameraSet()
    {
        while(!stopView)
        {
            yield return new WaitForSeconds(0.05f);

            var playerPos = Player.transform.position;
            stayPos = new Vector3(originX - 4, playerPos.y + 3.5f, playerPos.z);
            Vector3 randomPos = Random.insideUnitSphere;
            stayPos += randomPos;
        }
        Camera.GetComponent<CameraMove_2>().enabled = true;
        Camera.transform.localEulerAngles = new Vector3(20, 0, 0);
        Player.GetComponent<WizardCtrl>().rotSpeed = 2;
        this.enabled = false;
    }

    private void StartCollapse()
    {
        for(int i = 0; i < 3; i++)
        {
            Invoke("TriggerOn", i);
        }
    }

    private void TriggerOn()
    {
        triggers[triggerCnt].startCollapse = true;
        triggerCnt++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag.Equals("Player"))
        {
            start = true;
        }
    }
}
