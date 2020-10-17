using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCtrl : MonoBehaviour
{
    private TeleportCtrl teleport;

    private void Awake()
    {
        teleport = gameObject.GetComponent<TeleportCtrl>();
    }

    private void Update()
    {
        MouseClick();
    }

    private void MouseClick()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 35))
            {
                GameObject clickedObj = hit.transform.gameObject;

                if (clickedObj.transform.parent)
                    clickedObj = clickedObj.transform.parent.gameObject;

                if (clickedObj.transform.tag.Equals("Ready"))
                {
                    clickedObj.transform.tag = "Moving";
                }
                else if (clickedObj.transform.tag.Equals("Fixed"))
                {
                    teleport.teleportPlay(clickedObj);
                }
            }
        }
    }
}
