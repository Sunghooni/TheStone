using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapseCheck : MonoBehaviour
{
    public bool blockedCount = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag.Equals("Block"))
        {
            blockedCount = true;
        }
    }
}
