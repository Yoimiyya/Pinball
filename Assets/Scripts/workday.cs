using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class workday : MonoBehaviour
{
    private GameObject gameManager;
    private AudioSource hit;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        hit = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        hit.Play();
        if (gameManager.GetComponent<GameManager>().wifi)
        {
            gameManager.GetComponent<GameManager>().money += 200;
        } else
        {
            gameManager.GetComponent<GameManager>().money += 100;
        }
    }
}
