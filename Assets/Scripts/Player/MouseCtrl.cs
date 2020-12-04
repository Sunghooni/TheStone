using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCtrl : MonoBehaviour
{
    //BlockManager blockManager;
    private TeleportCtrl teleport;

    private void Awake()
    {
        //blockManager = GameObject.Find("BlockManager").GetComponent<BlockManager>();
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

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 30))
        {
            GameObject clickedObj = hit.transform.gameObject;

            if (clickedObj.transform.parent)
                clickedObj = clickedObj.transform.parent.gameObject;

            if(clickedObj.tag.Equals("Block"))
            {
                var objState = clickedObj.GetComponent<Block>().blockState;

                if (objState == Block.State.Ready)
                {
                    clickedObj.GetComponent<Block>().blockState = Block.State.Moving;
                }
                else if (objState == Block.State.Fixed)
                {
                    teleport.teleportPlay(hit.transform.gameObject);
                }
            }
        }
    }
}
