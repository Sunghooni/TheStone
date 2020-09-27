using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.XR;

public class WizardCtrl : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    Ray ray;
    RaycastHit hit;

    private float horz;
    private float vert;
    private float moveSpeed = 5;
    private float rotSpeed = 3;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MouseClick();
    }

    private void FixedUpdate()
    {
        MoveCtrl();
    }

    void MouseClick()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 30))
            {
                if (hit.transform.tag == "Fixed")
                {
                    Teleport(hit.transform.gameObject);
                    horz = 0;
                    vert = 0;
                }
                else
                    Debug.Log("It isn't able to Climb");
            }
        }
    }

    void MoveCtrl()
    {
        horz = Input.GetAxis("Horizontal") * rotSpeed;
        vert = Input.GetAxis("Vertical") * moveSpeed;

        transform.Translate(Vector3.forward * vert * Time.deltaTime);
        transform.Rotate(Vector3.up * horz);

        if (vert != 0 || horz != 0)
            anim.SetBool("run", true);
        else
            anim.SetBool("run", false);
    }

    void Teleport(GameObject obj)
    {
        var pos = obj.transform.position;
        this.transform.position = new Vector3(pos.x, pos.y + 1.5f, pos.z);
    }
}