using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSanddollars : MonoBehaviour
{
    public GameObject sanddollar;
    public int numToStart;
    public GameObject parent;

    private float spawnInterval = 3f;
    private float tempTime = 0f;

    public System.Random rand = new System.Random();

    private float x_coord;
    private float y_coord;

    public int maxdollars = 10;
    static public int currdollars = 0;

    void Start()
    {
        numToStart = 6;

        for(int i = 0; i < numToStart; i++)
        {
            spawnSanddollar();
        }
    
    }

    void Update()
    {
        tempTime += Time.deltaTime;
        while(tempTime >= spawnInterval) 
        {
          spawnSanddollar();
          tempTime -= spawnInterval;
        }

    }

    private void spawnSanddollar()
    {
        if (maxdollars != currdollars)
        {
            GameObject a = Instantiate(sanddollar) as GameObject;

            a.transform.position = new Vector2(Random.Range(-13f, 13f), Random.Range(-3f, 6.5f));
            a.transform.SetParent(parent.transform);

            // if (rand.Next(0, 3) == 0)
            // {   
            //     // left of castle
            //     x_coord = Random.Range(-13f,-2f);
            //     y_coord = Random.Range(-3f,7f);
            // }
            // if (rand.Next(0, 3) == 1)
            // {
            //     // right of castle
            //     x_coord = Random.Range(2f,13f);
            //     y_coord = Random.Range(-3f,7f);
            // }
            // else
            // {
            //     // beneath castle
            //     x_coord = Random.Range(-13f,13f);
            //     y_coord = Random.Range(--3f,3f);
            // }

            // a.transform.position = new Vector2(x_coord, y_coord);
            // a.transform.SetParent(parent.transform);

            currdollars++;

        }
    }
}
