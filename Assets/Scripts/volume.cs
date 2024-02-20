using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class volume : MonoBehaviour
{
    public AudioClip audioClip1;
    public AudioClip audioClip2;

    private AudioSource turnOn;
    private AudioSource turnOff;

    public bool pressed;

    // Start is called before the first frame update
    void Start()
    {
        turnOn = this.gameObject.AddComponent<AudioSource>();
        turnOff = this.gameObject.AddComponent<AudioSource>();
        turnOn.clip = audioClip1;
        turnOff.clip = audioClip2;
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        pressed = true;
        this.transform.position += new Vector3(-0.1f,0,0);
        turnOn.Play();
        
    }


    public void GoBack()
    {
        pressed = false;
        Invoke("DoIt", 2f);
        
    }

    private void DoIt()
    {
        turnOff.Play();
        this.transform.position += new Vector3(0.1f, 0, 0);
    }
}
