using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrabs : MonoBehaviour
{
    public GameObject crabPrefab;
    public float respawnTime = 10.0f;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(crabWave());
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(crabPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * -5);
    }

    IEnumerator crabWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
