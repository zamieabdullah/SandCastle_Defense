﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CrabMovement : MonoBehaviour
{
    private Vector3 target; 
 	private float speed = 1;
    // float wiggleDistance = 1;
    // float wiggleSpeed = 5;
	
    public AudioSource deflectCrabAudio;

    public PlayerController pc;
    public GameObject centerTower;

    private bool hasTower = false;
    private bool hitByPlayer = false;

    private SpriteRenderer crab;

    private GameObject capturedTower;

    public GameObject sandpile;

    public GameObject particlesPrefab;

    public bool hitByUpgradedCatcher = false;

    private void Start()
    {
        target = centerTower.transform.position;
    }

    void Update()
    { 
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

        if (hitByUpgradedCatcher)
        {
            hitByUpgradedCrabCatcher();
        }


        // float xPosition = Mathf.Sin(Time.time * wiggleSpeed) * wiggleDistance;

        // transform.localPosition = new Vector3(xPosition, 0, 0);
    }

	void OnTriggerEnter2D(Collider2D other)
	{

        if ((other.gameObject.CompareTag("castle")))
        {
            if ((hitByPlayer == false) && (hasTower == false))
            {
                capturedTower = other.gameObject;
                // removed the if statement for without destroying shovel: (other.gameObject.CompareTag("beachshovel")
                speed *= 5;
                target.y = -10;
                target.x = Random.Range(-20f, 20f);

                other.gameObject.tag = "tower";
                other.transform.parent = transform;
                hasTower = true;

                if (other.gameObject.name == "Center Tower")
                {
                    StartCoroutine(gameOver());
                }

                deflectCrabAudio.Play();
            }
        }

        if (((other.gameObject.CompareTag("trench")) || (other.gameObject.CompareTag("wetTrench"))) && gameObject.tag != "dead")
		{
			Debug.Log("crab hit trench!");
            speed = 0.5f; // TESTING SOMETHING
		}

        // to trap the very first crab
        if (other.gameObject.CompareTag("crabTrap"))
        {
            //Debug.Log("crab 1 trapped!");
            speed = 0f;
        }

        if ((other.gameObject.CompareTag("doubleTrench")))
        {
            Debug.Log("CRAB and DOUBLETRENCH");

            TrapCrab();

        }
        if ((other.gameObject.CompareTag("wetTrench")))
        {
            if (speed == 0)
            {
                Debug.Log("CRAB and wetTrench");
                gameObject.tag = "dead";
                Destroy(this.gameObject);
            }
        }
		
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Player")))
        {
            if (pc.has_crabcatcher && !pc.has_upgraded_catcher && Input.GetButtonDown("Hit") && gameObject.tag != "dead")
            {
                Debug.Log("CRABCATCHER HIT CRAB");

                hitByPlayer = true;

                if (hasTower)
                {
                    DropTower();
                    
                    //capturedTower.tag = "castle";
                    //Debug.Log("CASTLE NOW!!!!");

                }
                GetComponent<SpriteRenderer>().color = Color.gray;
                speed *= -5;
                //target.y = -10;
                //target.x = Random.Range(-20f, 20f);
                gameObject.tag = "dead";
                deflectCrabAudio.Play();
                PlayerController.crabsHit++;
            }


        }

    }
    void DropTower()
    {
        transform.DetachChildren();
        GameObject[] towers;
        towers = GameObject.FindGameObjectsWithTag("tower");
        foreach (GameObject tower in towers)
        {
            tower.tag = "castle";
        }

        hasTower = false;

        GameObject a = Instantiate(sandpile) as GameObject;
        a.transform.position = transform.position;

        GameObject ps = Instantiate(particlesPrefab, transform.position, Quaternion.identity);

        Destroy(capturedTower);

    }

    void TrapCrab()
    {
        Debug.Log("TrapCrab()");
    
        Vector3 theScale = transform.localScale;
        theScale.y *= -1;
        transform.localScale = theScale;
        // FALLINg ANIMATION
        speed = 0;
    }

    IEnumerator gameOver()
    {
        PlayerController.timePlayed = PlayerController.timePlayed + ((30 + (5 * Timer.currentLevel)) - Timer.timeLeft - 5);

        yield return new WaitForSeconds(3.5f);

        SceneManager.LoadScene("LoseScene");
    }

    public static GameObject FindGameObjectInChildWithTag(GameObject parent, string tag)
    {
        Transform t = parent.transform;

        for (int i = 0; i < t.childCount; i++)
        {
            if (t.GetChild(i).gameObject.tag == tag)
            {
                return t.GetChild(i).gameObject;
            }

        }

        return null;
    }

    void hitByUpgradedCrabCatcher()
    {
        if (gameObject.tag != "dead")
        {
            Debug.Log("CRABCATCHER HIT CRAB");

            hitByPlayer = true;

            if (hasTower)
            {
                DropTower();

                //capturedTower.tag = "castle";
                //Debug.Log("CASTLE NOW!!!!");

            }
            GetComponent<SpriteRenderer>().color = Color.gray;
            speed *= -5;
            //target.y = -10;
            //target.x = Random.Range(-20f, 20f);
            gameObject.tag = "dead";
            deflectCrabAudio.Play();
            PlayerController.crabsHit++;

            hitByUpgradedCatcher = false;
        }
    }


}