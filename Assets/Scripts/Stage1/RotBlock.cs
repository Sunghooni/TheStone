using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RotBlock : MonoBehaviour
{
    Vector3 rotPoint;
    public bool startRot = false;
    public bool isTriggerOn = false;

    private AudioSource audioSource = null;
    private GameObject AudioManager;
    SoundManager soundManager;

    void Awake()
    {
        var pos = this.transform.position;
        rotPoint = new Vector3(pos.x - 1.5f, pos.y - 1.5f, pos.z);

        if(gameObject.GetComponent<AudioSource>())
            audioSource = gameObject.GetComponent<AudioSource>();

        AudioManager = GameObject.FindWithTag("AudioManager");
        soundManager = AudioManager.GetComponent<SoundManager>();
    }

    private void Update()
    {
        if(startRot && this.transform.eulerAngles.z == 0)
        {
            StartCoroutine(RotMovement());
            if(audioSource != null)
                PlaySound("BridgeMaking");
        }
    }

    private void PlaySound(string name)
    {
        audioSource.clip = soundManager.GetAudioClip(name);
        audioSource.volume = soundManager.GetAudioVolume();
        Debug.Log(audioSource.volume);
        audioSource.Play();
    }

    IEnumerator RotMovement()
    {
        float RotSpeed = 0;
        while(true)
        {
            if (this.transform.eulerAngles.z > 89.9f)
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, 90);
                break;
            }
            transform.RotateAround(rotPoint, Vector3.forward, RotSpeed * Time.deltaTime);
            RotSpeed += Time.deltaTime * 10;
            yield return new FixedUpdate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isTriggerOn = true;
        
        Debug.Log("Hitted");
        other.gameObject.GetComponent<Block>().blockState = Block.State.Staying;
        other.gameObject.GetComponent<Block>().stopMove = true;
        
    }
}
