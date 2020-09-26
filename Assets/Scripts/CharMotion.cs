using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CharMotion : MonoBehaviour
{
    public GameObject hand;
    Animator anim;
    Ray ray;
    RaycastHit hit;

    float mouseX, mouseY;

    void Start()
    {
        anim = hand.GetComponent<Animator>();
    }
    void Update()
    {
        MouseClick();
        Moving();
    }
    void MouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 30) && hit.transform.name == "Cube")
            {
                StartCoroutine(Backon());
            }
        }
    }
    void Moving()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(new Vector3(1, 0, 0) * 10 * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(new Vector3(-1, 0, 0) * 10 * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(new Vector3(0, 0, -1) * 10 * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(new Vector3(0, 0, 1) * 10 * Time.deltaTime);

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.up * 3 * mouseX);
        hand.transform.Rotate(Vector3.back * 3 * -mouseY);
    }
    IEnumerator Backon()
    {
        anim.SetBool("DoBackon", true);
        while (true)
        {
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("Backon") &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f)
            {
                anim.SetBool("DoBackon", false);
                break;
            }
            yield return null;
        }
    }
}