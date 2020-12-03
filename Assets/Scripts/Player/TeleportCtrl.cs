using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class TeleportCtrl : MonoBehaviour
{
    public ParticleSystem TeleportPtc;
    private WizardCtrl wizardCtrl;
    public GameObject targetBlock;
    public bool teleportable = true;

    private float teleportDelay;

    private void Awake()
    {
        wizardCtrl = gameObject.GetComponent<WizardCtrl>();
        teleportDelay = TeleportPtc.startLifetime / 2;
    }

    public void teleportPlay(GameObject block)
    {
        if(teleportable)
        {
            teleportable = false;

            wizardCtrl.moveSpeed = 0;
            wizardCtrl.rotSpeed = 0;

            FindBlockToMove(block);
            StartCoroutine(TeleportEft());
        }
    }

    private void FindBlockToMove(GameObject obj)
    {
        RaycastHit hit;

        if (Physics.Raycast(obj.transform.position, Vector3.up, out hit, 3) && !hit.transform.name.Equals("Wizard"))
            FindBlockToMove(hit.transform.gameObject);
        else
            targetBlock = obj;
        return;
    }

    IEnumerator TeleportEft()
    {
        float timer = 0;
        var toPos = targetBlock.transform.position;

        TeleportPtc.Play();

        while (true)
        {
            timer += Time.deltaTime;

            if (timer > teleportDelay)
            {
                this.transform.position = new Vector3(toPos.x, toPos.y + 1.5f, toPos.z);
            }
            if(timer > teleportDelay * 2)
            {
                wizardCtrl.moveSpeed = 5;
                wizardCtrl.rotSpeed = 2;
                teleportable = true;
                break;
            }
            yield return null;
        }
    }
}
