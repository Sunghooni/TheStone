using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollpaseBlock : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent && collision.transform.parent.tag.Equals("Block"))
        {
            Debug.Log("Parent is Moveblock");
        }
        else if(!collision.transform.tag.Equals("Collapse") && !collision.transform.tag.Equals("Block"))
        {
            if(collision.transform.GetComponent<Rigidbody>() &&
               collision.transform.GetComponent<Rigidbody>().isKinematic)
            {
                collision.transform.GetComponent<Rigidbody>().isKinematic = false;
                collision.transform.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
}
