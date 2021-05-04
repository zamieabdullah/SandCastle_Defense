using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSandPiles : MonoBehaviour
{
    public GameObject sandpile;
    public int numToStart = 3;
    public GameObject parent;

    private float spawnInterval = 8f;
    private float tempTime = 0f;

    static public int currnumofpiles = 0;
    public int maxpiles = 5;

    public System.Random rand = new System.Random();

    void Start()
    {
        for(int i = 0; i < numToStart; i++)
        {
            spawnSandpile();
        }
    }

    void Update()
    {
        tempTime += Time.deltaTime;
        while(tempTime >= spawnInterval) 
        {
          spawnSandpile();
          tempTime -= spawnInterval;
        }
    }

    private void spawnSandpile()
    {
        if (maxpiles != currnumofpiles)
        {
            GameObject a = Instantiate(sandpile) as GameObject;

            if (rand.Next(0, 2) == 0)
            {
                // left edge
                a.transform.position = new Vector2(Random.Range(-11f, -6f), Random.Range(-3f, 6f));
            }
            else
            {
                // right edge
                a.transform.position = new Vector2(Random.Range(6f, 11f), Random.Range(-3f, 6f));
            }

            a.transform.SetParent(parent.transform);

            currnumofpiles++;
        }
    }
}
