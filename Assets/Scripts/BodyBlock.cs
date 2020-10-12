using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBlock : MonoBehaviour
{
    public GameObject ParentBlock;
    HeadBlock hdBlock;

    private void Awake()
    {
        hdBlock = ParentBlock.GetComponent<HeadBlock>();
    }

    public void OnTriggerEnter(Collider other)
    {
        GameObject parent = other.transform.gameObject;

        if (other.transform.parent)
            parent = parent.transform.parent.gameObject;

        if (parent.tag == "Moving" || parent.tag == "Fixed")
        {
            hdBlock.stopMove = true;
            Debug.Log("Hit");
        }
    }
}
