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

    private float currentLevel = 1;

    // PRIVATE DECLARATIONS
    private TimeSpan timePlaying;        //TimeSpan part of System namespace
                                         // used to format Time better

    //private bool timerIsRunning = false;         //true when game starts, false when ends

    //private float timeLeft;           //holds Time.deltaTime value
    public float timeLeft;

    public GameObject crab;


    Vector2 whereToSpawn;

    // private void Awake()
    // {
    //     instance = this;
    // }

    private void Start()
    {
        countDisplay.text = "Wave1: 01:00.00";

        PlayLevelX(currentLevel);

        //BeginTimer(currentLevel);
        
    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(timeLeft);
 
            countDisplay.text = "Wave Duration: " + timePlaying.ToString("mm':'ss");
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
        }
        else 
        {
            PlayLevelX(currentLevel++);
        }
    }

    private void PlayLevelX(float currentLevel)
    {   
        timeLeft = 30 + (5*currentLevel);

        StartCoroutine(GracePeriod());
        
        WaterAttack();

    }

    IEnumerator GracePeriod() // RIGHT NOW THIS GRACE PERIOD ISN'T WAITING
    {
        Debug.Log("grace period");
        float wait_time = 10 + (2 * currentLevel);
        yield return new WaitForSeconds(wait_time);

        CrabsAttack();
        //GetComponent<BoxCollider2D>().enabled = true;
    }

    private void CrabsAttack()
    {
        float crabCountToSpawn = (5 * currentLevel);
        for (int i = 0; i < crabCountToSpawn; i++)
        {
            SpawnCrab(); // right now they all spawn at the same time but fix later
        }
    }

    private void WaterAttack()
    {
        //coming soon
    }



    // public void BeginTimer(float level)
    // {
    //     //timerIsRunning = true;
    //     timeLeft = (5 * level); // CHANGE THIS AS NECESSARY 


    //     PlayLevelX(currentLevel);
    //     StartCoroutine(UpdateTimer());
    // }

    // public void EndTimer()
    // {
    //     //timerIsRunning = false;

    //     Debug.Log("timer ended");
    //     BeginTimer(currentLevel++);
    //     // timerIsRunning = false;
    //     // SceneManager.LoadScene("WinScene");
    // }


    // IEnumerator PlayLevelX(float currentLevel)
    // {
    //     GracePeriod(currentLevel);
    //     CrabsAttack(currentLevel);
    //     WaterAttack(currentLevel);

    //     yield return null;
    // }

    // IEnumerator GracePeriod(float currentLevel)
    // {
    //     Debug.Log("grace period");
    //     float wait_time = 10 + (2 * currentLevel);
    //     yield return new WaitForSeconds(wait_time);
    //     //GetComponent<BoxCollider2D>().enabled = true;
    // }

    // IEnumerator CrabsAttack(float currentLevel)
    // {
    //    // make 5 * currentLevel # crabs attack across ___ seconds

    //     Debug.Log("crabs attack");
        
    
    //     float crabCountToSpawn = (5 * currentLevel);
    //     for (int i = 0; i < crabCountToSpawn; i++)
    //     {
    //         SpawnCrab(); // right now they all spawn at the same time but fix later
    //     }

    //     yield return null;
    // }
     
    // IEnumerator WaterAttack(float currentLevel)
    // {
    //     // coming soon
    //     yield return null;
    // }




    // private IEnumerator UpdateTimer()
    // {
    //     while (timeLeft > 0)
    //     {
    //         timeLeft -= Time.deltaTime;

    //         timePlaying = TimeSpan.FromSeconds(timeLeft);
    //         if (timeLeft >= 0.00)
    //         {
    //             countDisplay.text = "Wave Duration: " + timePlaying.ToString("mm':'ss");
    //         }

    //         // THIS IS WHERE WE DETERMINE CRAB WAVES... one crab per 0.01
    //         // if ((timeLeft >= 59.96 & timeLeft <= 60.00) | (timeLeft >= 39.96 & timeLeft <= 40.00) | (timeLeft >= 19.96 & timeLeft <= 20.00))
    //         // {
    //         //     Debug.Log("spawn crabs");
    //         //     SpawnCrab();
                
    //         // }

    //         if (timeLeft <= 15.00)
    //         {
    //             if (timeLeft <= 5.00)
    //             {
    //                 countDisplay.color = Color.red;
    //             }
    //             else
    //             {
    //                 countDisplay.color = Color.yellow;
    //             }
    //         }

    //         if (timeLeft <= 0.00)
    //         {
    //             EndTimer();
                
               
    //         }
            
    //         yield return null;
            
    //     }

    // }

    void SpawnCrab()
    {
        Vector2 whereToSpawn = new Vector2(Random.Range(-20f, 20f), -5f);

        Instantiate(crab, whereToSpawn, Quaternion.identity);
    }

}