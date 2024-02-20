using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Burst.CompilerServices;

public class GameManager : MonoBehaviour
{
    public int hour;
    public int minute;
    public int money;
    public int health;
    public string dayText;
    public string informationText;
    public GameObject score;
    public GameObject moneyText;
    public GameObject information;
    public GameObject day;
    public GameObject highScore;
    public GameObject button;
    public GameObject objects;
    public GameObject ballPrefab;
    public GameObject home;

    public bool wifi;
    public bool night;
    public bool tired;

    private int highScoreNumber;

    public GameObject up;
    public GameObject down;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        wifi = false;
        highScoreNumber = 0;
        InvokeRepeating("IncrementCount", 1f, 1f);
        dayText = "Normal Day";
        informationText = "go fix internet";
        tired = false;
        GameObject.Find("HighScore").SetActive(false);
        GameObject.Find("Button").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        information.GetComponent<TextMeshProUGUI>().text = informationText;
        day.GetComponent<TextMeshProUGUI>().text = dayText;
        moneyText.GetComponent<TextMeshProUGUI>().text = "$" + money;
        if (score != null) {
            if (minute < 10)
            {
                score.GetComponent<TextMeshProUGUI>().text = hour.ToString() + ":0" + minute.ToString();
            }
            else if (minute < 60)
            {
                score.GetComponent<TextMeshProUGUI>().text = hour.ToString() + ":" + minute.ToString();
            }
            else
            {
                minute = 0;
                hour++;
            }
            if (hour >= 24)
            {
                hour = 0;
            }


            //check time
            if (hour >= 17)
            {
                night = true;
            }
            if (hour >= 7 && hour < 17)
            {
                night = false;
            }
        }

        //if night
        if (night)
        {
            dayText = "Normal Night";
            informationText = "Time to\nTurn off";
            if (hour >= 21)
            {
                tired = true;
            }
        } else
        {
            dayText = "Normal Day";
        }

        //if tired
        if (tired)
        {
            dayText = "Tired  Night";
            informationText = "Getting Tired...\nStop Working!";
        }

        //if died
        if(health <= 0)
        {
            GameEnd();
        }

        if (up.GetComponent<volume>().pressed && down.GetComponent<volume>().pressed)
        {
            home.GetComponent<home>().ballnumber++;
            Instantiate(ballPrefab);
            up.GetComponent<volume>().GoBack();
            down.GetComponent<volume>().GoBack();
        }
    }

    void IncrementCount()
    {
        minute++;
    }

    void GameEnd()
    {
        home.GetComponent<home>().ballnumber = 1;
        up.GetComponent<volume>().pressed = false;
        up.transform.position = new Vector3(-2.2f,2.21f,0);
        down.GetComponent<volume>().pressed = false;
        down.transform.position = new Vector3(-2.2f, 1.51f, 0);
        objects.SetActive(false);
        highScore.SetActive(true);
        if (money > highScoreNumber)
        {
            highScore.GetComponent<TextMeshProUGUI>().text = "HighScore: $" + money;
            highScoreNumber = money;
        }
        button.SetActive(true);
    }

}
