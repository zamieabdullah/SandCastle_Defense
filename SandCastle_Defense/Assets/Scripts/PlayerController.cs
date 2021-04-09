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
    //public Tilemap tilemapColliders;

    public Transform attachPoint;
    public GameObject trench;

    public TextMeshProUGUI sanddollarCountText;
	  public Animator animator;
    public int sanddollarCount;
	  private bool looking_right = true;
    
    public bool has_shovel = false;
    public bool has_bucket = false;
    public bool bucketIsEmpty = true;

    public GameObject trenchParent;

    private AudioSource sanddollarAudio;
    private AudioSource digAudio;
    private AudioSource pickUpShovelAudio;

	  Vector2 movement;

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
                //print("space key was pressed");
                DigTrench();
            }
            else
            {
                Debug.Log("Get your darn shovel before you can dig!");
            }
            
        }
		
		
		if (Input.GetButtonDown("Equip"))
        {
            Debug.Log("you are equiping! " + Time.deltaTime);
            
        }
		
		
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
            pickUpShovelAudio.Play();

            Destroy(other.gameObject);
            has_shovel = true;
						animator.SetBool("Shovel", has_shovel);

                /* no need to attach shovel to head now: 
            other.transform.parent = attachPoint;
			      other.transform.localRotation = Quaternion.Euler(0, 0, 135f); */
        }

        if (other.gameObject.CompareTag("bucket"))
        {
            Debug.Log("Yay you got the bucket");
            has_bucket = true;
            other.transform.parent = attachPoint;
        }

        if(other.gameObject.CompareTag("sandpile"))
        {
            if (has_bucket == true)
            {
                //fill bucket with sand
                bucketIsEmpty = false;
                Destroy(other.gameObject);
                
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

            if(bucketIsEmpty == false)
            {
                //C ASTLE GROWS AND GAINS AN "APPENDAGE" @CHRIS

                // maybe here we should also give the castle more health somehow?

                bucketIsEmpty = true;
                kidSpeed = 5f;
            }
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


    void DigTrench()
    {
    	digAudio.Play();

        // get current grid location
        Vector3Int currCell = tilemapBG.WorldToCell(transform.position);

        // delete the tile there
        tilemapBG.SetTile(currCell, null);

        //creates trench GameObject at the position of the player
        GameObject thisTrench = Instantiate(trench, currCell, transform.rotation);
		thisTrench.SetActive(true);
        thisTrench.transform.SetParent(trenchParent.transform);

    }



    void SetUpAudio()
    {        
        AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
        sanddollarAudio = allMyAudioSources[0];
        digAudio = allMyAudioSources[1];
        pickUpShovelAudio = allMyAudioSources[2];
    }


}

