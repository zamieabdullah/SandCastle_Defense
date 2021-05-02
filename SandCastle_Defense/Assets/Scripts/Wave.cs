﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Wave : MonoBehaviour
{
    public GameObject centerTower;
    private Vector3 target;
    public Material Mat_WaveProjectile1;
    private float curr_visibility = 4f;
    private float speed = 1;


    // Start is called before the first frame update
    void Start()
    {
        target.x = transform.position.x;
        target.y = transform.position.y + 12f;
        target.z = transform.position.z;

        curr_visibility = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if (transform.position.y > 2f)
        {
            curr_visibility = curr_visibility - 0.1f;
            if (curr_visibility > 0.01f)
            {
                Mat_WaveProjectile1.SetFloat("Visibility", curr_visibility);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("waveBlocker")) //NOT REGISTERING COLLISION, IDK WHY
        {
            Debug.Log("hit waveblocker");
            speed = 0f;
        }

        if (collision.CompareTag("castle"))
        {
            Debug.Log("hit rock");
            Destroy(gameObject);

            if (collision.gameObject.name == "Center Tower")
            {
                Debug.Log("hit centerTower");
                SceneManager.LoadScene("LoseScene");

            }
        }

        if ((collision.gameObject.CompareTag("trench")) || (collision.gameObject.CompareTag("wetTrench")))
        {
            Destroy(gameObject);
        }



    }
}
