using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHealth : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit");

        if (other.gameObject.CompareTag("crab"))
        {
            TakeDamage(5);
        }
    }

    void TakeDamage(int damage)
    {
        Debug.Log("damage");

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
