using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class CastleHealth : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;

    public HealthBar healthBar;

    public SpriteRenderer spriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;


    // Start is called before the first frame update
    void Start()
    {
        //spriteRenderer.sprite = sprite3;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit");

        if (other.gameObject.CompareTag("crab"))
        {
            TakeDamage(5);
            ChangeSprite();
        }
    }

    void LevelOver()
    {
        if (currentHealth == 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }


    void TakeDamage(int damage)
    {
        Debug.Log("damage");

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }

        
    }

    void ChangeSprite()
    {
        if (currentHealth == 15)
        {
            spriteRenderer.sprite = sprite2;
        }
        if (currentHealth == 10)
        {
            spriteRenderer.sprite = sprite1;

        }
        
    }
}
