﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    public static Timer instance;    //allows Timer functions to be called 
                                         //from other scripts/ classes outside

    public Text countDisplay;            //Text variable for GameObject reference


    // PRIVATE DECLARATIONS
    private TimeSpan timePlaying;        //TimeSpan part of System namespace
                                         // used to format Time better

    private bool timerIsRunning;         //true when game starts, false when ends

    private float timeLeft;           //holds Time.deltaTime value


    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        countDisplay.text = "Wave1: 01:00.00";
        timerIsRunning = false;
        BeginTimer();

    }


    public void BeginTimer()
    {
        timerIsRunning = true;
        timeLeft = 30f; //0.5 minute 

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerIsRunning = false;
        SceneManager.LoadScene("WinScene");
    }


    private IEnumerator UpdateTimer()
    {


        while (timerIsRunning)
        {
            timeLeft -= Time.deltaTime;


            timePlaying = TimeSpan.FromSeconds(timeLeft);
            if (timeLeft >= 0.00)
            {
                countDisplay.text = "Wave Duration: " + timePlaying.ToString("mm':'ss");
            }

            if (timeLeft <= 15.00)
            {
                if (timeLeft <= 5.00)
                {
                    countDisplay.color = Color.red;
                }
                else
                {
                    countDisplay.color = Color.yellow;
                }
            }
            if (timeLeft <= 0.00)
            {
                Debug.Log("timer ended");
                EndTimer();
            }
           
            yield return null;
        }



    }

}