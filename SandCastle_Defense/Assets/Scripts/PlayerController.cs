using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

	public float kidSpeed = 5f;

	public Rigidbody2D rb;

    public TextMeshProUGUI sanddollarCountText;
    private int sanddollarCount;


	Vector2 movement;

    void Start()
    {
        sanddollarCount = 0;
        SetSanddollarCountText();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
    	rb.MovePosition(rb.position + movement * kidSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
      
        if(other.gameObject.CompareTag("sanddollar"))
        {
            
            sanddollarCount++;
            Destroy(other.gameObject);


            SetSanddollarCountText();
        }

    }

    void SetSanddollarCountText()
    {
        sanddollarCountText.text = "Sanddollar Count: " + sanddollarCount.ToString();
        
    }
        

}
