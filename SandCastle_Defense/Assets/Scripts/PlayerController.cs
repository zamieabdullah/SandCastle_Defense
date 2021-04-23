using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class PlayerController : MonoBehaviour
{

	public float kidSpeed = 5f;

	public Rigidbody2D rb;

    public Tilemap tilemapBG;
    public Tilemap tilemapColliders;
    public RuleTile trenchRuleTileDry;
    public RuleTile trenchRuleTileWet;
    

    public Transform attachPoint;
    public GameObject trench;

    public TextMeshProUGUI sanddollarCountText;
	  public Animator animator;
    public int sanddollarCount;
	  private bool looking_right = true;

    //So player can only hold one item at a time
    private GameObject current_item;
		public GameObject inventory;
    public bool has_item = false;
    public bool has_shovel = false;
    public bool has_bucket = false;
    public bool has_crabcatcher = false;
    
    public bool bucketFilled = false;
    private int digs_left = 5;

    public GameObject trenchParent;

    private AudioSource sanddollarAudio;
    private AudioSource digAudio;
    private AudioSource pickUpShovelAudio;

	  Vector2 movement;

    public int bucketAmount = 0;

    public GameObject castleTower;

    public showShop showShop;

    void Start()
    {
        sanddollarCount = 0;
        SetSanddollarCountText();

        SetUpAudio();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal") * kidSpeed;
        movement.y = Input.GetAxisRaw("Vertical") * kidSpeed;
				
				if (Mathf.Abs(movement.x) > 0.01) {
					  animator.SetFloat("Speed", Mathf.Abs(movement.x));
				} else if (Mathf.Abs(movement.y) > 0.01) {
					  animator.SetFloat("Speed", Mathf.Abs(movement.y));
				} else {
					  animator.SetFloat("Speed", (float)0.00);
				}
				
				if (movement.x < 0 && looking_right) {
				    Flip();
				} else if (movement.x > 0 && !looking_right) {
					  Flip();
				}

        if (Input.GetButtonDown("Dig"))
        {
            if (has_shovel == true)
            {   
                 //this should always run
                 if (digs_left > 0)
                 {

                    DigTrench();
                    Debug.Log("digs left after digging = " + digs_left);


                    if (digs_left == 0)
                    {
                        Debug.Log("0000000 digs left");
                        
                        has_shovel = false;
                        has_item = false;
                        Destroy(current_item);
												digs_left = 5;

                        //shovel disappears off the kid
                        animator.SetBool("Shovel", has_shovel);

                    }

                 }
            
            }
            else
            {
                Debug.Log("Get your shovel before you can dig!");
            }
            
        }
		
		
		if (Input.GetButtonDown("Equip") && (has_item == true))
        {
            PutDown();
        }

        if (Input.GetButtonDown("Build"))
        {
            if (bucketAmount <= 0)
            {
                Debug.Log("Your bucket is empty!");
            }
            else
            { 
                Instantiate(castleTower, transform.position, Quaternion.identity);
                bucketAmount -= 2; 
            }
        }
		
		
    }

    IEnumerator EnableBox(float wait_time)
    {
        yield return new WaitForSeconds(wait_time);
        GetComponent<BoxCollider2D>().enabled = true;
    }

    void FixedUpdate()
    {
    	rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }



    void OnTriggerEnter2D(Collider2D other)
    {      
        if(other.gameObject.CompareTag("sanddollar"))
        {
            sanddollarAudio.Play();
            sanddollarCount++;
            Destroy(other.gameObject);
			
            SetSanddollarCountText();
        }

        //functionality is just collecting shovel for now
        if (other.gameObject.CompareTag("beachshovel"))
        {
            if (has_item == true)
            {
                PutDown();
            }

            if (has_item == false)
            {
                pickUpShovelAudio.Play();

                //removed 'digs_left = 5' because player shouldn't get more digs by putting down the shovel!
                //Destroy(other.gameObject);
                other.gameObject.SetActive(false);
                has_shovel = true;
                has_item = true;
                current_item = other.gameObject;
                animator.SetBool("Shovel", has_shovel);

                     /* no need to attach shovel to head now: 
                    other.transform.parent = attachPoint;
			         other.transform.localRotation = Quaternion.Euler(0, 0, 135f); */
            }
            else
            {
                Debug.Log("You can only pick up one item at a time!");
            }
        }

        if (other.gameObject.CompareTag("bucket"))
        {
            if (has_item == true)
            {
                PutDown();
            }

            if (has_item == false)
            {
                Debug.Log("Yay you got the bucket");
								other.gameObject.SetActive(false);
                has_bucket = true;
                has_item = true;
                current_item = other.gameObject;
								animator.SetBool("Bucket", has_bucket);
            }
            else
            {
                Debug.Log("You can only pick up one item at a time!");
            }
        }


        if (other.gameObject.CompareTag("crabcatcher"))
        {
            if (has_item == true)
            {
                PutDown();
            }

            if (has_item == false)
            {
                Debug.Log("crabcatcher obtained!");
								other.gameObject.SetActive(false);
                has_item = true;
                has_crabcatcher = true;
                current_item = other.gameObject;
                // other.transform.parent = attachPoint;
								animator.SetBool("CrabCatcher", has_crabcatcher);
            }
        }

        if(other.gameObject.CompareTag("sandpile"))
        {
        

            if (has_bucket == true)
            {
                //fill bucket with sand
                bucketFilled = true;
                bucketAmount += 2;
                Destroy(other.gameObject);
                animator.SetBool("BucketFull", bucketFilled);
                kidSpeed = 3f;
            }
            else
            {
                Debug.Log("you need a bucket to get this sand");
            }
        }

        if (other.gameObject.CompareTag("castle"))
        {
            Debug.Log("player collided with sandcastle");

            if(bucketFilled == true)
            {

                //C ASTLE GROWS AND GAINS AN "APPENDAGE" @CHRIS

                // maybe here we should also give the castle more health somehow?

                bucketFilled = false;
								animator.SetBool("BucketFull", bucketFilled);
                kidSpeed = 5f;
            }
        }

        //show shop
        if (other.gameObject.CompareTag("physicalshop"))
        {
            Debug.Log("Opening Shop");
            showShop.shop.SetActive(true);
            //pause game
            Time.timeScale = 0f;
        }
    }
		
	private void Flip()
			{
					// Switch the way the player is labelled as facing.
					looking_right = !looking_right;

					// Multiply the player's x local scale by -1.
					Vector3 theScale = transform.localScale;
					theScale.x *= -1;
					transform.localScale = theScale;
			}

    public void SetSanddollarCountText()
    {
        sanddollarCountText.text = sanddollarCount.ToString();
        
    }

    //trenches will only last for 10 seconds of the game
    void DigTrench()
    {
    	digAudio.Play();

        // get current grid location
        Vector3Int currCell = tilemapColliders.WorldToCell(transform.position);

        // replace the tile there with trenchRuleTile
        tilemapColliders.SetTile(currCell, trenchRuleTileWet);

        //creates trench GameObject at the position of the player
        GameObject thisTrench = Instantiate(trench, currCell, transform.rotation);
		thisTrench.SetActive(true);
        thisTrench.transform.SetParent(trenchParent.transform);
        //Destroy(thisTrench, 10f);

        //subtracts digs left
        digs_left--;
    }



    void SetUpAudio()
    {        
        AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
        sanddollarAudio = allMyAudioSources[0];
        digAudio = allMyAudioSources[1];
        pickUpShovelAudio = allMyAudioSources[2];
    }

    void PutDown()
    {
        Debug.Log("you are letting go! " + Time.deltaTime);
        if (has_shovel == true)
        {
            has_shovel = false;
            animator.SetBool("Shovel", has_shovel);
        }
        if (has_crabcatcher == true)
        {
            has_crabcatcher = false;
            animator.SetBool("CrabCatcher", has_crabcatcher);
        }
        if (has_bucket == true)
        {
            has_bucket = false;
            animator.SetBool("Bucket", has_bucket);
        }

        //copying the trench digging functionality
        GetComponent<BoxCollider2D>().enabled = false;
        Vector3Int currCell = tilemapBG.WorldToCell(transform.position);
        GameObject clone = Instantiate(current_item, currCell , transform.rotation);
        clone.SetActive(true);
        clone.transform.SetParent(trenchParent.transform);
        has_item = false;
        Destroy(current_item);
        StartCoroutine(EnableBox(0.5f));
    }

}

