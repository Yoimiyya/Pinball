using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ball : MonoBehaviour
{
    private GameObject gameManager;
    private AudioSource hit;

    void Start()
    {
        transform.localScale = new Vector3(0.3f, 0.3f, 1);
        transform.position = new Vector3(Random.Range(-0.3f, 0.3f), 4.1f, 0);
        gameManager = GameObject.Find("GameManager");
        hit = this.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the collided object has a specific tag
        if (other.gameObject.CompareTag("point"))
        {
            hit.Play();
            gameManager.GetComponent<GameManager>().minute += 5;
            if (gameManager.GetComponent<GameManager>().wifi)
            {
                gameManager.GetComponent<GameManager>().money += 6;
            } else
            {
                gameManager.GetComponent<GameManager>().money += 3;
            }
            
            
            //minute++;
        }
    }

}
