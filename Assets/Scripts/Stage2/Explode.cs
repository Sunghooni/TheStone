using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public float range;
    public float power, upPower;
    public bool triggerSelect = false;
    public bool trigger = false;

    private bool showOnce = true;

    private void Update()
    {
        if (!triggerSelect && trigger && showOnce)
        {
            StartCoroutine("ExplodeNormalBlock");
            showOnce = false;
        }
        if (triggerSelect && trigger && showOnce)
        {
            StartCoroutine("ExplodeMoveBlock");
            showOnce = false;
        }
    }

    void ExplodeNormalBlock()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, range);

        foreach (Collider coll in colls)
        {
            Rigidbody rbody = coll.GetComponent<Rigidbody>();

            if (rbody != null && !coll.tag.Equals("Player") && !coll.tag.Equals("Block"))
            {
                if (coll.transform.parent && coll.transform.parent.tag.Equals("Block"))
                    continue;
                rbody.isKinematic = false;
                rbody.useGravity = true;
                rbody.AddExplosionForce(power, transform.position, upPower);
            }
        }
    }

    void ExplodeMoveBlock()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, range);

        foreach (Collider coll in colls)
        {
            Rigidbody rbody = coll.GetComponent<Rigidbody>();

            if (rbody != null && coll.tag.Equals("Block"))
            {
                rbody.isKinematic = false;
                rbody.useGravity = true;
                rbody.AddExplosionForce(power, transform.position, upPower);
            }
            for (int i = 0; i < coll.transform.childCount; i++)
            {
                GameObject obj = coll.transform.GetChild(i).gameObject;
                
                if (obj != null && obj.GetComponent<Rigidbody>())
                {
                    coll.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
                    coll.transform.GetChild(i).GetComponent<Rigidbody>().useGravity = true;
                    coll.transform.GetChild(i).GetComponent<Rigidbody>().AddExplosionForce(power, transform.position, upPower);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag.Equals("Player"))
        {
            trigger = true;
        }
    }
}
