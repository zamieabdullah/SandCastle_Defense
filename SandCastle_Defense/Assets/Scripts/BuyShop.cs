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
        Debug.Log("BUYING ITEM " + playercontroller.sanddollarCount);
        if (playercontroller.sanddollarCount > 2)
        {
            playercontroller.sanddollarCount = playercontroller.sanddollarCount - 3;
            playercontroller.SetSanddollarCountText();
        } else
        {
            Debug.Log("CANNOT BUY!!! Collect sand dollars");
        }
        Debug.Log("New sanddollar count: " + playercontroller.sanddollarCount);
    }
}
