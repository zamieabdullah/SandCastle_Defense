using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class PlayerController : MonoBehaviour
{

	public float kidSpeed = 5f;

	public Rigidbody2D rb;
    public Tilemap tilemap;
    public GameObject player;
    public GameObject trench;

    public TextMeshProUGUI sanddollarCountText;
	public Animator animator;
    public int sanddollarCount;
	private bool looking_right = true;
    private bool has_shovel = false;
    private AudioSource audioSource;

	Vector2 movement;

    void Start()
    {
        sanddollarCount = 0;
        SetSanddollarCountText();

        audioSource = GetComponent<AudioSource>();
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

        if (Input.GetKeyDown("space"))
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
    }

    void FixedUpdate()
    {
    	rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
      
        if(other.gameObject.CompareTag("sanddollar"))
        {
            audioSource.Play();
            sanddollarCount++;
            Destroy(other.gameObject);


            SetSanddollarCountText();
        }

        //functionality is just collecting shovel for now
        if (other.gameObject.CompareTag("beachshovel"))
        {
            //Destroy(other.gameObject);
            has_shovel = true;
            other.transform.parent = transform;
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
        sanddollarCountText.text = "Sanddollar Count: " + sanddollarCount.ToString();
        
    }


    void DigTrench()
    {
        // get current grid location
        Vector3Int currCell = tilemap.WorldToCell(player.transform.position);

        // delete the tile there
        tilemap.SetTile(currCell, null);
        Instantiate(trench);

    }

}
