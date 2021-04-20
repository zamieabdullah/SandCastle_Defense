using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castle : MonoBehaviour
{
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("wave"))
        {
            Debug.Log("tower hit wave and is destroyed");
            Destroy(gameObject);
        }
    }
}
