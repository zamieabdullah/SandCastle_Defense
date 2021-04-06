using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showShop : MonoBehaviour
{
    public GameObject shop;
    public PlayerController playercontroller;
    public Button showbutton, hidebutton;

    void Start()
    {
        shop = GameObject.FindWithTag("shop");
        shop.SetActive(false);
    }

    void Update()
    {
        showbutton.onClick.AddListener(showStore);
        hidebutton.onClick.AddListener(hideStore);
    }
    //show shop
    public void showStore()
    {
        shop.SetActive(true);
    }
    //hide store
    public void hideStore()
    {
        shop.SetActive(false);
    }

}
