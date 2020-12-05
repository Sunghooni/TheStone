﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Block : MonoBehaviour
{
    public enum State { Unmovable, Ready, Moving, Staying, Backing, Fixed }
    public State blockState = State.Ready;

    public float MoveDistance;
    public float MoveSpeed;
    public float StayTime;

    public bool freeze = false;
    public bool stopMove = false;

    private Vector3 originPos = Vector3.zero;
    private Vector3 toPos = Vector3.zero;
    private bool canGo = true;

    private AudioSource audioSource;
    private GameObject AudioManager;
    SoundManager soundManager;

    void Awake()
    {
        originPos = this.transform.position;
        toPos = originPos + transform.right * -MoveDistance;

        audioSource = gameObject.GetComponent<AudioSource>();
        AudioManager = GameObject.FindWithTag("AudioManager");
        soundManager = AudioManager.GetComponent<SoundManager>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (blockState == State.Moving && canGo)
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

            if(blockState == State.Moving)
            {
                this.transform.position = Vector3.Lerp(originPos, toPos, timer / MoveSpeed);
                if (timer > MoveSpeed)
                {
                    blockState = State.Staying;
                    timer = 0;
                }
            }
            else if(blockState == State.Staying)
            {
                if (stopMove)
                {
                    PlaySound("RockCollide");
                    blockState = State.Fixed;
                    break;
                }
                else if (timer > StayTime)
                {
                    blockState = State.Backing;
                    timer = 0;
                }
            }
            else if(blockState == State.Backing)
            {
                this.transform.position = Vector3.Lerp(toPos, originPos, timer / MoveSpeed);
                if(timer > MoveSpeed)
                {
                    blockState = State.Ready;
                    canGo = true;
                    break;
                }
            }
            yield return new WaitForFixedUpdate();
        }
    }

    private void PlaySound(string name)
    {
        audioSource.clip = soundManager.GetAudioClip(name);
        audioSource.volume = soundManager.GetAudioVolume();
        Debug.Log(audioSource.volume);
        audioSource.Play();
    }

    public void OnTriggerEnter(Collider other)
    {
        GameObject triggerObj = other.transform.gameObject;

        if (other.transform.parent)
            triggerObj = other.transform.parent.gameObject;
        if (!triggerObj.transform.tag.Equals("Block"))
        {
            return;
        }
        if (other.GetComponent<Rigidbody>() && other.GetComponent<Rigidbody>().useGravity)
        {
            return;
        }

        var triggerState = triggerObj.GetComponent<Block>().blockState;

        if (triggerState == State.Moving || triggerState == State.Fixed || triggerState == State.Staying)
        {
            if(triggerObj.GetComponent<Block>())
            {
                triggerObj.GetComponent<Block>().stopMove = true;
            }
            stopMove = true;
        }
    }
}