using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml;
using UnityEngine;
using UnityEngine.XR;

public class WizardCtrl : MonoBehaviour
{
    Animator anim;
    Ray ray;
    RaycastHit MouseHit;
    RaycastHit BlockHit;

    private float horz;
    private float vert;
    private float moveSpeed = 5;
    private float rotSpeed = 2;

    public GameObject toBlock;
    public ParticleSystem TeleportPtc;
    public bool movable = true;

    void Start()
    {
        anim = GetComponent<Animator>();
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
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out MouseHit, 30))
            {
                if (MouseHit.transform.tag == "Ready")
                {
                    MouseHit.transform.gameObject.GetComponent<Renderer>().material.color = Color.red;
                    MouseHit.transform.tag = "Moving";
                }
                if(MouseHit.transform.tag == "Fixed")
                {
                    if (MouseHit.transform.tag == "Fixed")
                    {
                        FindBlockToMove(MouseHit.transform.gameObject);
                        StartCoroutine(TeleportEft());
                    }
                    else
                        Debug.Log("Nothing to Climb");
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
    }

    IEnumerator TeleportEft()
    {
        float timer = 0;
        TeleportPtc.Play();

        movable = false;
        anim.SetBool("run", false);

        while (true)
        {
            timer += Time.deltaTime;
            if (timer > 1.5f)
            {
                var toPos = toBlock.transform.position;
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

    void FindBlockToMove(GameObject obj)
    {
        if (Physics.Raycast(obj.transform.position, Vector3.up, out BlockHit, 3))
            FindBlockToMove(BlockHit.transform.gameObject);
        else
            toBlock = obj;

        return;
    }
}