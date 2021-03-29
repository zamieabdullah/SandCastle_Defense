using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

	public float kidSpeed = 5f;

	public Rigidbody2D rb;

  public TextMeshProUGUI sanddollarCountText;
	public Animator animator;
  private int sanddollarCount;
	private bool looking_right = true;


	Vector2 movement;

    void Start()
    {
        sanddollarCount = 0;
        SetSanddollarCountText();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal") * kidSpeed;
        movement.y = Input.GetAxisRaw("Vertical") * kidSpeed;
				
				animator.SetFloat("Speed", Mathf.Abs(movement.x));
				
				if (movement.x < 0 && looking_right) {
				    Flip();
				} else if (movement.x > 0 && !looking_right) {
					  Flip();
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
            
            sanddollarCount++;
            Destroy(other.gameObject);


            SetSanddollarCountText();
        }

        //functionality is just collecting shovel for now
        if (other.gameObject.CompareTag("beachshovel"))
        {
            //Destroy(other.gameObject);
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

    void SetSanddollarCountText()
    {
        sanddollarCountText.text = "Sanddollar Count: " + sanddollarCount.ToString();
        
    }
        

}
