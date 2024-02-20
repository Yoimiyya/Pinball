using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class power : MonoBehaviour
{
    private GameObject gameManager;
    private GameObject wifi;
    private GameObject atnt;
    private AudioSource hit;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        wifi = GameObject.Find("wifi");
        atnt = GameObject.Find("at&t");
        hit = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (gameManager.GetComponent<GameManager>().night)
        {
            hit.Play();
            this.transform.position += new Vector3(0.1f, 0, 0);
            gameManager.GetComponent<GameManager>().hour = 7;
            gameManager.GetComponent<GameManager>().minute = 0;
            gameManager.GetComponent<GameManager>().tired = false;
            Invoke("GoBack", 2f);
        } else
        {
            gameManager.GetComponent<GameManager>().informationText = "You Still Have Job to Do!";

            if (wifi.GetComponent<SpriteRenderer>().sprite != atnt.GetComponent<atnt>().wifi4)
            {
                Invoke("FixInternet", 3f);
            } else
            {
                Invoke("KeepWork", 3f);
            }
            
        }
        
    }

    void GoBack()
    {
        this.transform.position += new Vector3(-0.1f, 0, 0);
    }

    void KeepWork()
    {
        gameManager.GetComponent<GameManager>().informationText = "Keep Working!"; // Set the new text
    }

    void FixInternet()
    {
        gameManager.GetComponent<GameManager>().informationText = "Go Fix Internet"; // Set the new text
    }
}
