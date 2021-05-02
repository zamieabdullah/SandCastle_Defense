using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using TMPro;

public class Timer : MonoBehaviour
{
    // PUBLIC DECLARATIONS
    public static Timer instance;    //allows Timer functions to be called 
                                         //from other scripts/ classes outside

    public Text countDisplay;            //Text variable for GameObject reference

    CrabMovement crabMovement;
    public PlayerController pc;

    public TextMeshProUGUI currentLevelText;
    public static float currentLevel = 1;


    // PRIVATE DECLARATIONS
    private TimeSpan timePlaying;        //TimeSpan part of System namespace
                                         // used to format Time better

    public static float timeLeft = 0f;

    public GameObject crab;
    public GameObject bigcrab;



    public GameObject wave;

    private bool waveRisen = false;

    public GameObject centerTower;
    private Vector3 target;
    private float speed = 5;

    private Vector3 waveSpawnLocation;



    private void Start()
    {
        target = centerTower.transform.position;
        waveSpawnLocation.x = wave.transform.position.x;
        waveSpawnLocation.y = -7;

        PlayLevelX();
    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(timeLeft);
 
            countDisplay.text = "Time until next wave: " + timePlaying.ToString("mm':'ss");
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
            countDisplay.color = Color.white;

            currentLevel++;
            PlayLevelX();

            PlayerController.timePlayed = PlayerController.timePlayed + (30 + (5 * currentLevel));
        }
    }

    private void PlayLevelX()
    {   
        SetCurrentLevelText();
        SetPlayerStats();

        StartCoroutine(GracePeriod());

        Debug.Log("time left is " + timeLeft);

        if (timeLeft <= 0)
        {
            timeLeft = 5 + (5 * currentLevel);   // MOVED FROM LINE 84 TO HERE INSIDE IF STATEMENT
            
            //if (!waveRisen)
            //{
                Debug.Log("wave should be coming");
                WaterAttack();
            //}
            
        }
        //wave.SetActive(false);

        
    }

    IEnumerator GracePeriod()
    {
        Debug.Log("grace period");
        float wait_time = 10 + (2 * currentLevel);
        yield return new WaitForSeconds(wait_time);

        CrabsAttack();
    }

    private void CrabsAttack()
    {
        float crabCountToSpawn = (5 * currentLevel);
        float bigcrabCountToSpawn = (1 * currentLevel);
        for (int i = 0; i < crabCountToSpawn; i++)
        {
            SpawnCrab(); 
        }
        for (int i = 0; i < bigcrabCountToSpawn; i++)
        {
            SpawnBigCrab(); 
        }
    }

    private void WaterAttack()
    {
        //coming soon
        //waveRisen = true;
        //wave.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        //wave.transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        //wave.SetActive(true);
        Instantiate(wave, waveSpawnLocation, Quaternion.identity);
        waveRisen = true;
        //m_Rigidbody.velocity = transform.up * m_Speed;



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
        Vector2 whereToSpawn = new Vector2(Random.Range(-20f, 20f), Random.Range(-30f, -5f));

        Instantiate(crab, whereToSpawn, Quaternion.identity);
    }

    void SpawnBigCrab()
    {
        Vector2 whereToSpawn = new Vector2(Random.Range(-20f, 20f), Random.Range(-15f, -5f));

        Instantiate(bigcrab, whereToSpawn, Quaternion.identity);
    }

    public void SetCurrentLevelText()
    {
        currentLevelText.text = "Level : " + currentLevel.ToString();;
    }

    private void SetPlayerStats()
    {
        PlayerController.numbOfLevels = currentLevel - 1;
    }

}