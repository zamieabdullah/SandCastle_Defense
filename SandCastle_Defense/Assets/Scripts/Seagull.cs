using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagull : MonoBehaviour
{
    public Animator animator;
    private bool in_flight;

    // Start is called before the first frame update
    void Start()
    {
        in_flight = false;
        animator.SetBool("is_flying", in_flight);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("wave"))
        {
                in_flight = true;
                animator.SetBool("is_flying", in_flight);
          
        }
        else
        {
            in_flight = false;
            animator.SetBool("is_flying", in_flight);
        }
    }
}
