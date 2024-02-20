using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finger : MonoBehaviour
{

    private Rigidbody2D right, left;
    public float strength;
    private GameObject gameManager;
    private bool bad;
    private AudioSource hit;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DecreaseStrength", 1f, 1f);
        strength = 40f;
        right = GameObject.Find("fingerRight").GetComponent<Rigidbody2D>();
        left = GameObject.Find("fingerLeft").GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager");
        hit = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Z))
        {
            if (!hit.isPlaying)
            {
                hit.Play();
            }
            left.AddTorque(strength);
        } else
        {
            left.AddTorque(-25f);
        }
        if (Input.GetKey(KeyCode.M))
        {
            if (!hit.isPlaying)
            {
                hit.Play();
            }
            right.AddTorque(-strength);
        }
        else
        {
            right.AddTorque(25);
        }

        if (gameManager.GetComponent<GameManager>().tired && bad)
        {
            strength = 10f;
            bad = false;
        }
    }
    void DecreaseStrength()
    {
        if (gameManager.GetComponent<GameManager>().tired)
        {
            strength -= 0.5f;
        }
        else
        {
            bad = true;
            strength = 40f;
        }
    }
}
