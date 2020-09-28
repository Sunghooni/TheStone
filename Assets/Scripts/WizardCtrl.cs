using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    private float rotSpeed = 2;

    public ParticleSystem TeleportPtc;
    public bool movable = true;

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
        if(movable)
            MoveCtrl();
    }

    void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 30))
            {
                if (hit.transform.tag == "Untagged")
                {
                    Debug.Log("Movable");
                }
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

        if (Input.GetKeyDown(KeyCode.Space))
            TeleportCheck();
    }

    void TeleportCheck()
    {
        var mePos = this.transform.position;

        if (Physics.Raycast(new Vector3(mePos.x, mePos.y + 1, mePos.z), transform.forward * 5, out hit))
        {
            if (hit.transform.tag == "Fixed")
                StartCoroutine(TeleportEft());
            else
                Debug.Log("It isn't able to Climb");
        }
    }

    IEnumerator TeleportEft()
    {
        Debug.Log("1");
        float timer = 0;
        TeleportPtc.Play();

        movable = false;
        anim.SetBool("run", false);

        while (true)
        {
            timer += Time.deltaTime;
            if (timer > 1.5f)
            {
                var toPos = hit.transform.position;
                this.transform.position = new Vector3(toPos.x, toPos.y + 1.5f, toPos.z);
            }
            if(timer > 3)
            {
                movable = true;
                break;
            }
            yield return null;
        }
    }
}