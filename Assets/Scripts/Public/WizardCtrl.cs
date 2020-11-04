using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using UnityEngine;
using UnityEngine.XR;

public class WizardCtrl : MonoBehaviour
{
    private Animator anim;
    private float horz = 0;
    private float vert = 0;

    public float moveSpeed = 5;
    public float rotSpeed = 2;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        MoveCtrl();
        AnimCtrl();
    }

    private void MoveCtrl()
    { 
        vert = Input.GetAxisRaw("Vertical") * moveSpeed;
        transform.Translate(Vector3.forward * vert * Time.deltaTime);

        horz = Input.GetAxis("Horizontal") * rotSpeed;
        transform.Rotate(Vector3.up * horz);
    }

    private void AnimCtrl()
    {
        if (vert != 0 || horz != 0)
            anim.SetBool("run", true);
        else
            anim.SetBool("run", false);
    }
}