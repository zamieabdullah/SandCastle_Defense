using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnCrabs : MonoBehaviour
{
    public GameObject[] crab;
    //public GameObject timer;

    Vector2 whereToSpawn;
    public float spawnRate = .5f;
    float nextSpawn;


    public GameObject timer;
   // public GameObject timer = GameObject.Find("TimeText");
    //Timer newtimer = GetComponent<Timer>;
   

    void Start()
    {
        timer = GameObject.Find("TimeText");
        
        Vector2 crabPos = new Vector2(Random.Range(-20f, 20f), -5f);

        transform.position = crabPos;
    }

    void Update()
    {
        Timer newtimer = timer.GetComponent<Timer>();

        if (newtimer.timeLeft < 10f)
        {
            //nextSpawn = Time.time + spawnRate;
            whereToSpawn = new Vector2(Random.Range(-20f, 20f), -5f);

            for (int i = 0; i < crab.Length; i++)
            {
                Instantiate(crab[i], whereToSpawn, Quaternion.identity);
            }
            
        }

    }
}
