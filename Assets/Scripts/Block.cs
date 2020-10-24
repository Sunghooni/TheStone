using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Block : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clips;
    public float MoveDistance = 0;
    public float MoveSpeed;
    public float StayTime;
    public bool freeze = false;

    private Vector3 originPos = Vector3.zero;
    private Vector3 toPos = Vector3.zero;
    private bool canGo = true;
    private bool stopMove = false;

    void Awake()
    {
        originPos = this.transform.position;
        toPos = originPos + transform.right * -MoveDistance;
    }

    private void FixedUpdate()
    {
        Move();
        //Debug.DrawRay(gameObject.transform.position, -transform.right * 2, Color.red, 1);
    }

    public void Move()
    {
        if (this.transform.tag.Equals("Moving") && canGo)
        {
            StartCoroutine(Moving());
            canGo = false;
        }
    }

    IEnumerator Moving()
    {
        float timer = 0;

        while (true)
        {
            if(!freeze)
            {
                timer += Time.deltaTime;
            }
            else
                audioSource.Pause();

            if(this.transform.tag.Equals("Moving"))
            {
                this.transform.position = Vector3.Lerp(originPos, toPos, timer / MoveSpeed);
                if (stopMove)
                {
                    gameObject.tag = "Fixed";
                    break;
                }
                else if (timer > MoveSpeed)
                {
                    this.transform.tag = "Staying";
                    timer = 0;
                }
            }
            else if(this.transform.tag.Equals("Staying"))
            {
                if (stopMove)
                {
                    gameObject.tag = "Fixed";
                    break;
                }
                else if (timer > StayTime)
                {
                    this.transform.tag = "Backing";
                    timer = 0;
                }
            }
            else if(this.transform.tag.Equals("Backing"))
            {
                this.transform.position = Vector3.Lerp(toPos, originPos, timer / MoveSpeed);
                if(timer > MoveSpeed)
                {
                    this.transform.tag = "Ready";
                    canGo = true;
                    break;
                }
            }
            yield return new WaitForFixedUpdate();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        GameObject triggerObj = other.transform.gameObject;

        if (other.transform.parent)
            triggerObj = other.transform.parent.gameObject;

        if (triggerObj.tag == "Moving" || triggerObj.tag == "Fixed" || triggerObj.tag == "Staying")
        {
            Debug.Log("Hit");
            stopMove = true;

            audioSource.clip = clips[0];
            audioSource.Play();
        }
    }
}