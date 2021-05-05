using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BigCrabMovement : MonoBehaviour
{
    private Vector3 target;
    private float speed = .8f;
    private int health;
    // float wiggleDistance = 1;
    // float wiggleSpeed = 5;
    public AudioSource deflectCrabAudio;

    public PlayerController pc;
    public GameObject centerTower;

    private bool hasTower = false;
    private bool hitByPlayer = false;

    private GameObject capturedTower;
    public GameObject sandpile;

    public GameObject particlesPrefab;

    public int towerstaken = 0;
    Vector3 temp = new Vector3(0, 0, 0);

    private void Start()
    {
        target = centerTower.transform.position;
        health = 3;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

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
                towerstaken++;

                other.gameObject.tag = "tower";
                other.transform.parent = transform;
                if (towerstaken == 2)
                {
                    speed *= 5;
                    target.y = -10;
                    target.x = Random.Range(-20f, 20f);
                    hasTower = true;
                }

                if (other.gameObject.name == "Center Tower")
                {
                    StartCoroutine(gameOver());
                }


                deflectCrabAudio.Play();
            }
        }

        if (other.gameObject.CompareTag("trench"))
        {
            Debug.Log("crab hit trench!");
            speed = 0.5f; // TESTING SOMETHING
        }

        //to trap the very first crab
        if (other.gameObject.CompareTag("crabTrap"))
        {
            Debug.Log("crab 1 trapped!");
            speed = 0f;
        }



    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Player")))
        {
            if (pc.has_crabcatcher && Input.GetButtonDown("Hit"))
            {
                StartCoroutine("EnemyFlash");
                //Debug.Log("CRABCATCHER HIT BIGCRAB");
                if (health == 0)
                {

                    hitByPlayer = true;

                    if (hasTower)
                    {

                        //foreach (Transform t in gameObject.transform)
                        //{
                        //    t.gameObject.tag = "castle";
                        //}
                        DropTower();

                    }
                    GetComponent<SpriteRenderer>().color = Color.gray;
                    speed *= 5;
                    target.y = -10;
                    target.x = Random.Range(-20f, 20f);
                    deflectCrabAudio.Play();
                    PlayerController.crabsHit++;
                }
                deflectCrabAudio.Play();
                health--;
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
            GameObject a = Instantiate(sandpile) as GameObject;
            a.transform.position = transform.position + temp;

            GameObject ps = Instantiate(particlesPrefab, transform.position, Quaternion.identity);

            temp = new Vector3(0, .5f, 0);

            Destroy(tower);
        }

        hasTower = false;
    }

    public IEnumerator EnemyFlash ()
    {
        GetComponent<Renderer>().material.color = Color.gray;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Renderer>().material.color = Color.white;
        StopCoroutine("EnemyFlash");
    }

    IEnumerator gameOver()
    {
        PlayerController.timePlayed = PlayerController.timePlayed + ((30 + (5 * Timer.currentLevel)) - Timer.timeLeft);

        yield return new WaitForSeconds(3.5f);

        SceneManager.LoadScene("LoseScene");
    }
}