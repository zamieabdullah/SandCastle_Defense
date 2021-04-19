using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Timer : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    public static Timer instance;    //allows Timer functions to be called 
                                         //from other scripts/ classes outside

    public Text countDisplay;            //Text variable for GameObject reference

    CrabMovement crabMovement;
    //public PlayerController pc;
    //public GameObject centerTower;


    // PRIVATE DECLARATIONS
    private TimeSpan timePlaying;        //TimeSpan part of System namespace
                                         // used to format Time better

    private bool timerIsRunning;         //true when game starts, false when ends

    //private float timeLeft;           //holds Time.deltaTime value
    public float timeLeft;

    public GameObject crab;
    Vector2 whereToSpawn;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        countDisplay.text = "Wave1: 01:00.00";
        timerIsRunning = false;
        BeginTimer();

        //crabMovement = GetComponent<CrabMovement>();
        //crabMovement.centerTower = centerTower;
        //crabMovement.pc = pc;

    }


    public void BeginTimer()
    {
        timerIsRunning = true;
        timeLeft = 90f; //0.5 minute 

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

            // THIS IS WHERE WE DETERMINE CRAB WAVES... one crab per 0.01
            if ((timeLeft >= 59.96 & timeLeft <= 60.00) | (timeLeft >= 39.96 & timeLeft <= 40.00) | (timeLeft >= 19.96 & timeLeft <= 20.00))
            {
                Debug.Log("spawn crabs");
                SpawnCrab();
                
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

    void SpawnCrab()
    {
        Vector2 whereToSpawn = new Vector2(Random.Range(-20f, 20f), -5f);

        Instantiate(crab, whereToSpawn, Quaternion.identity);
    }


}