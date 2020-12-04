using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explore : MonoBehaviour
{
    private void Awake()
    {
        Invoke("Explode", 3f);
    }

    void Explode()
    {
        //지정한 원점을 중심으로 10.0f 반경 내에 들어와 있는 Collider 객체 추출
        Collider[] colls = Physics.OverlapSphere(transform.position, 10.0f);

        //추출한 Collider 객체에 폭발력 전달
        foreach (Collider coll in colls)
        {
            Rigidbody rbody = coll.GetComponent<Rigidbody>();
            if (rbody != null)
            {
                rbody.mass = 1.0f;
                rbody.AddExplosionForce(2000.0f, transform.position, 10.0f);
            }
        }
    }
}
