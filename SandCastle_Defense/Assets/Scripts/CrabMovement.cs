using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CrabMovement : MonoBehaviour
{
 	private Vector3 target = new Vector3(0, 2, 0);
 	private float speed = 1;
    // float wiggleDistance = 1;
    // float wiggleSpeed = 5;

	public Transform attackPoint;
	public float attackRange = .000005f;
	public LayerMask castleLayer;

    public AudioSource deflectCrabAudio;
    public PlayerController pc;

    public GameObject centerTower;


    private void Start()
    {
		SpawnCrab();
		attackPoint = gameObject.transform;
        

    }

    void Update()
    { 
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
      
	    // float xPosition = Mathf.Sin(Time.time * wiggleSpeed) * wiggleDistance;

	    // transform.localPosition = new Vector3(xPosition, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if ( (other.gameObject.CompareTag("castle")) )
		{
            // removed the if statement for without destroying shovel: (other.gameObject.CompareTag("beachshovel")
            speed *= 5;
			target.y = -5;
			target.x = Random.Range(-20f, 20f);

            other.gameObject.tag = "tower";
            other.transform.parent = transform;

            if (other.gameObject.name == "Center Tower")
            {
                StartCoroutine(gameOver());
            }
            
            StartCoroutine(destroyTower(other.gameObject));

            deflectCrabAudio.Play();

		}

        if ( (other.gameObject.CompareTag("Player")) )
        {
            if (pc.has_crabcatcher)
            {
                speed *= 5;
                target.y = -5;
                target.x = Random.Range(-20f, 20f);
                deflectCrabAudio.Play();
            }
            

        }

        if (other.gameObject.CompareTag("trench"))
		{
			Debug.Log("crab hit trench!");
            speed *= 0.5f;
		}


		
	}

	void SpawnCrab()
    {
		Vector2 crabPos = new Vector2(Random.Range(-20f, 20f), -5f);

		transform.position = crabPos;
    }



	void Attack()
    {
        //animator.SetTrigger ("Attack");
        
        Collider2D[] hitCastles = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, castleLayer);     //2D
        

        foreach(Collider2D castle in hitCastles)
        {
            //2D, change Collider2D to Collider for 3D
            Debug.Log("We hit " + castle.name);
            //target and attack the nearest castle
        }
        
    }


	   //to help see the attack sphere in editor:
   void OnDrawGizmosSelected()
   {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
   }

   IEnumerator destroyTower(GameObject tower)
   {
        yield return new WaitForSeconds(5);

        Destroy(tower);
   }

   IEnumerator gameOver()
   {
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("LoseScene");
   }

}