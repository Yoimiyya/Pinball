using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class home : MonoBehaviour
{
    private GameObject gameManager;
    public GameObject ball;
    public GameObject ballPrefab;
    private AudioSource hit;

    public int ballnumber;
    // Start is called before the first frame update
    void Start()
    {
        ballnumber = 1;
        gameManager = GameObject.Find("GameManager");
        ball = GameObject.Find("Ball");
        hit = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hit.Play();
        Destroy(collision.gameObject);
        ballnumber--;
        if (ballnumber == 0)
        {
            gameManager.GetComponent<GameManager>().health--;
            if (gameManager.GetComponent<GameManager>().health > 0)
            {

                Invoke("Return", 3f);
            }
        }
    }

    void Return()
    {
        if (gameManager.GetComponent<GameManager>().health > 0)
        {
            ballnumber++;
            ball = Instantiate(ballPrefab);
        }
    }
}
