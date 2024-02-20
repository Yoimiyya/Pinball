using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class bouncer : MonoBehaviour
{
    private AudioSource hit;
    // Start is called before the first frame update
    void Start()
    {
        hit = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the collided object has a specific tag
            hit.Play();
    }
}
