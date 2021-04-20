using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showShop : MonoBehaviour
{
    public GameObject shop;
    public PlayerController playercontroller;
    public Button hidebutton;
    SpriteRenderer shopSprite;

    void Start()
    {
        shop = GameObject.FindWithTag("shop");
        shop.SetActive(false);
        shopSprite = GetComponent<SpriteRenderer>();
        shopSprite.color = Color.grey;
    }

    void Update()
    {
        hidebutton.onClick.AddListener(hideStore);
        if (playercontroller.sanddollarCount > 2)
        {
            shopSprite.color = Color.white;
        }
    }

    ////show shop, moved to playercontroller script since random spawning of sanddollars triggered this
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("physicalshop"))
    //    {
    //        Debug.Log("Opening Shop");
    //    }
    //    shop.SetActive(true);
    //    //pause game
    //    Time.timeScale = 0f;
    //}

    //hide store
    public void hideStore()
    {
        shop.SetActive(false);
        Time.timeScale = 1f;
    }

}
