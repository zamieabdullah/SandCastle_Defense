using System.Collections;
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


    private void Start()
    {
        target = centerTower.transform.position;
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
            if (hasTower == false)
            {
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
                Debug.Log("CRABCATCHER HIT CRAB");

                if (hasTower)
                {
                    transform.DetachChildren();
                }

                speed *= 5;
                target.y = -10;
                target.x = Random.Range(-20f, 20f);
                deflectCrabAudio.Play();
                PlayerController.crabsHit++;
            }


        }
    }

    IEnumerator gameOver()
   {
        PlayerController.timePlayed = PlayerController.timePlayed + ((30 + (5 * Timer.currentLevel)) - Timer.timeLeft);

        yield return new WaitForSeconds(3.5f);

        SceneManager.LoadScene("LoseScene");
   }

}