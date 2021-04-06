using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showShop : MonoBehaviour
{
    public GameObject shop;
    public PlayerController playercontroller;
    public Button showbutton, hidebutton, itemOne, itemTwo, itemThree, itemFour;

    void Start()
    {
        shop = GameObject.FindWithTag("shop");
        shop.SetActive(false);
    }

    void Update()
    {
        showbutton.onClick.AddListener(showStore);
        hidebutton.onClick.AddListener(hideStore);
        buyitems();
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

    public void buyitems()
    {
        itemOne.onClick.AddListener(buyItemone);
        itemTwo.onClick.AddListener(buyItemtwo);
        itemThree.onClick.AddListener(buyItemthree);
        itemFour.onClick.AddListener(buyItemfour);
    }

    public void buyItemone()
    {
        Debug.Log("BUYING ITEM ONE " + playercontroller.sanddollarCount);
        playercontroller.sanddollarCount--;
        Debug.Log("New sanddollar count: " + playercontroller.sanddollarCount);
    }

    public void buyItemtwo()
    {
        Debug.Log("BUYING ITEM TWO " + playercontroller.sanddollarCount);
        playercontroller.sanddollarCount--;
        Debug.Log("New sanddollar count: " + playercontroller.sanddollarCount);
    }

    public void buyItemthree()
    {
        Debug.Log("BUYING ITEM THREE " + playercontroller.sanddollarCount);
        playercontroller.sanddollarCount--;
        Debug.Log("New sanddollar count: " + playercontroller.sanddollarCount);
    }

    public void buyItemfour()
    {
        Debug.Log("BUYING ITEM FOUR " + playercontroller.sanddollarCount);
        playercontroller.sanddollarCount--;
        Debug.Log("New sanddollar count: " + playercontroller.sanddollarCount);
    }

}
