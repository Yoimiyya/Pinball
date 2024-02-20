using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class buttonUI : MonoBehaviour
{
    public GameObject highScore;
    public GameObject button;
    public GameObject objects;
    private GameObject gameManager;
    private GameObject home;
    public GameObject ballPrefab;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        home = GameObject.Find("HomeButton");
    }
    // Start is called before the first frame update
    public void NewGameButton()
    {
        gameManager.GetComponent<GameManager>().wifi = false;
        gameManager.GetComponent<GameManager>().health = 2;
        objects.SetActive(true);
        highScore.SetActive(false);
        button.SetActive(false);
        home.GetComponent<home>().ball = Instantiate(ballPrefab);
        gameManager.GetComponent<GameManager>().money = 0;
        gameManager.GetComponent<GameManager>().hour = 7;
        gameManager.GetComponent<GameManager>().minute = 0;
    }
}
