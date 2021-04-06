using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyShop : MonoBehaviour
{
    public PlayerController playercontroller;
    public Button purchase;

    public void purchaseItem()
    {
        Debug.Log("BUYING ITEM ONE " + playercontroller.sanddollarCount);
        if (playercontroller.sanddollarCount > 0)
        {
            playercontroller.sanddollarCount--;
            playercontroller.SetSanddollarCountText();
        }
        Debug.Log("New sanddollar count: " + playercontroller.sanddollarCount);
    }
}
