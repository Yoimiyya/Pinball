using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class atnt : MonoBehaviour
{
    private GameObject gameManager;
    private GameObject wifi;
    public Sprite wifi1;
    public Sprite wifi2;
    public Sprite wifi3;
    public Sprite wifi4;
    private AudioSource hit;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        wifi = GameObject.Find("wifi");
        hit = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (gameManager.GetComponent<GameManager>().money >= 150 && wifi.GetComponent<SpriteRenderer>().sprite != wifi4 && !gameManager.GetComponent<GameManager>().night)
        {
            hit.Play();
            gameManager.GetComponent<GameManager>().money -= 150;
            wifi.GetComponent<SpriteRenderer>().sprite = wifi4;
            gameManager.GetComponent<GameManager>().wifi = true;
            gameManager.GetComponent<GameManager>().informationText = "Salary\nIncreases";
            Invoke("KeepWork", 3f);

        } else if (gameManager.GetComponent<GameManager>().money < 150 && wifi.GetComponent<SpriteRenderer>().sprite != wifi4 && !gameManager.GetComponent<GameManager>().night)
        {
            gameManager.GetComponent<GameManager>().informationText = "Insufficient\nFunds";
            Invoke("FixInternet", 3f);
        }
        
        if (!wifi)
        {
            wifi.GetComponent<SpriteRenderer>().sprite = wifi1;
        }
    }

    void FixInternet()
    {
        gameManager.GetComponent<GameManager>().informationText = "Go Fix Internet"; // Set the new text
    }

    void KeepWork()
    {
        gameManager.GetComponent<GameManager>().informationText = "Keep Working!"; // Set the new text
    }
}
