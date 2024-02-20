using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class island : MonoBehaviour
{
    private bool decrease = false;
    private bool increase = false;
    private AudioSource hit;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        increase = true;  
        hit.Play();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
        
    }
    private void Start()
    {
        hit = this.gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (increase)
        {
            this.transform.localScale += new Vector3(0.01f, 0.01f, 0);
        }
        
        if (decrease)
        {
            increase = false;
            this.transform.localScale -= new Vector3(0.01f, 0.01f, 0);
        }
        if (this.transform.localScale.x >= 1.2)
        {
            decrease = true;
        }
        if (this.transform.localScale.x <= 1)
        {
            decrease = false;
        }
    }
}
