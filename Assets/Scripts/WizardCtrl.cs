using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class WizardCtrl : MonoBehaviour
{
    Animator anim;
    Ray ray;
    RaycastHit hit;

    public float horz;
    private float vert;
    private float moveSpeed = 5;
    private float rotSpeed = 10;

    void Start()
    {

    }

    void Update()
    {
        MouseClick();
    }

    private void FixedUpdate()
    {
        MotionCtrl();
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

    void MotionCtrl()
    {
        horz = Input.GetAxis("Horizontal") * rotSpeed;
        vert = Input.GetAxis("Vertical") * moveSpeed;
        transform.Translate(Vector3.forward * vert * Time.deltaTime);
        transform.Rotate(Vector3.up * horz * Time.deltaTime);
    }
}