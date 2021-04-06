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
    public Sprite sprite4;

    private AudioSource crabAttackAudio;

    // Start is called before the first frame update
    void Start()
    {
        //spriteRenderer.sprite = sprite3;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        SetUpAudio();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit");


        if (other.gameObject.CompareTag("crab"))
        {
            TakeDamage(5);
            ChangeSprite();
            crabAttackAudio.Play();
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
            //SceneManager.LoadScene("LoseScene");
            StartCoroutine(WaitForSceneLoad());
        }


        
    }

    void ChangeSprite()
    {
        if (currentHealth == 15)
        {
            spriteRenderer.sprite = sprite1;

        }
        else if (currentHealth == 10)
        {
            spriteRenderer.sprite = sprite2;
        }
        else if (currentHealth == 5)
        {
            spriteRenderer.sprite = sprite3;
        }
        else 
        {
            spriteRenderer.sprite = sprite4;
        }
        
        
    }

    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("LoseScene");

    }

    void SetUpAudio()
    {        
        AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
        crabAttackAudio = allMyAudioSources[0];
        
    }
}
