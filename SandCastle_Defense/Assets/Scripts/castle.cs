using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class castle : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("wave"))
        {
            if (gameObject.name == "Center Tower")
            {
                SceneManager.LoadScene("LoseScene");
            }

            Debug.Log("tower hit wave and is destroyed");
            Destroy(gameObject);
        }
    }
}
