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
        GameObject a = Instantiate(sanddollar) as GameObject;
        a.transform.position = new Vector2(Random.Range(-13f, 13f), Random.Range(-3f, 7f));
        a.transform.SetParent(parent.transform);
    }
}
