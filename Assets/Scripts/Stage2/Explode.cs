using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject[] DropBlocks;
    public float range;
    public bool trigger = false;

    private bool showOnce = true;

    private void Update()
    {
        if (trigger && showOnce)
        {
            StartCoroutine("BlockDrop");
            showOnce = false;
        }
    }

    void ExplodeAll()
    {
        //지정한 원점을 중심으로 10.0f 반경 내에 들어와 있는 Collider 객체 추출
        Collider[] colls = Physics.OverlapSphere(transform.position, range);

        //추출한 Collider 객체에 폭발력 전달
        foreach (Collider coll in colls)
        {
            Rigidbody rbody = coll.GetComponent<Rigidbody>();

            if (rbody != null && !coll.tag.Equals("Player"))
            {
                rbody.isKinematic = false;
                rbody.useGravity = true;
                rbody.AddExplosionForce(230, transform.position, 100f);
            }
        }
    }

    IEnumerator BlockDrop()
    {
        foreach(GameObject obj in DropBlocks)
        {
            yield return new WaitForSeconds(1.5f);
            obj.GetComponent<Rigidbody>().isKinematic = false;
            obj.GetComponent<Rigidbody>().useGravity = true;
        }
        ExplodeAll();
        yield return null;
    }
}
