using System.Collections;
using System.Collections.Generic;
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
        if(Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 30) && hit.transform.name == "Cube")
            {
                Debug.Log("WipWIp");
            }
        }
    }

    void MoveCtrl()
    {
        horz = Input.GetAxis("Horizontal") * rotSpeed;
        vert = Input.GetAxis("Vertical") * moveSpeed;
        transform.Translate(Vector3.forward * vert * Time.deltaTime);
        transform.Rotate(Vector3.up * horz);

        if(Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(JumpMotion());
        if (vert != 0)
            anim.SetBool("run", true);
        else
            anim.SetBool("run", false);
    }

    IEnumerator JumpMotion()
    {
        float timer = 0;
        bool jump = true;
        anim.SetBool("jump", true);

        while (true)
        {
            timer += Time.deltaTime;
            if(timer > 0.3f && jump)
            {
                jump = false;
                rb.AddForce(Vector3.up * 500);
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jump") && 
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f)
            {
                anim.SetBool("jump", false);
                break;
            }
            yield return null;
        }
    }
}