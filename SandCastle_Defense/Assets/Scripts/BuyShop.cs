using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyShop : MonoBehaviour
{
    public PlayerController playercontroller;
    public Button purchase;
    public GameObject item, parent;
    public Text feedbackText;

    public void purchaseShovel()
    {
        Debug.Log("BUYING SHOVEL " + playercontroller.sanddollarCount);
        if (playercontroller.sanddollarCount > 2)
        {
            playercontroller.sanddollarCount = playercontroller.sanddollarCount - 3;
            playercontroller.SetSanddollarCountText();

            GameObject a = Instantiate(item) as GameObject;
            a.transform.position = new Vector2(Random.Range(-10f, 10f), Random.Range(-3f, 5f));
            a.transform.SetParent(parent.transform);
            feedbackText.color = Color.green;
            feedbackText.text = "Successful Purchase!";
        } else
        {
            feedbackText.color = Color.red;
            feedbackText.text = "Get more sand dollars!";
            Debug.Log("CANNOT BUY!!! Collect sand dollars");
        }
        Debug.Log("New sanddollar count: " + playercontroller.sanddollarCount);
    }

    public void purchaseCrabcatcher()
    {
        Debug.Log("BUYING CRAB CATCHER " + playercontroller.sanddollarCount);
        if (playercontroller.sanddollarCount > 2)
        {
            playercontroller.sanddollarCount = playercontroller.sanddollarCount - 3;
            playercontroller.SetSanddollarCountText();

            GameObject a = Instantiate(item) as GameObject;
            a.transform.position = new Vector2(Random.Range(-10f, 10f), Random.Range(-3f, 5f));
            a.transform.SetParent(parent.transform);
            feedbackText.color = Color.green;
            feedbackText.text = "Successful Purchase!";
        }
        else
        {
            feedbackText.color = Color.red;
            feedbackText.text = "Get more sand dollars!";
            Debug.Log("CANNOT BUY!!! Collect sand dollars");
        }
        Debug.Log("New sanddollar count: " + playercontroller.sanddollarCount);
    }

    public void purchaseBucket()
    {
        Debug.Log("BUYING BUCKET " + playercontroller.sanddollarCount);
        if (playercontroller.sanddollarCount > 2)
        {
            playercontroller.sanddollarCount = playercontroller.sanddollarCount - 3;
            playercontroller.SetSanddollarCountText();

            GameObject a = Instantiate(item) as GameObject;
            a.transform.position = new Vector2(Random.Range(-10f, 10f), Random.Range(-3f, 5f));
            a.transform.SetParent(parent.transform);
            feedbackText.color = Color.green;
            feedbackText.text = "Successful Purchase!";

        }
        else
        {
            feedbackText.color = Color.red;
            feedbackText.text = "Get more sand dollars!";
            Debug.Log("CANNOT BUY!!! Collect sand dollars");
        }
        Debug.Log("New sanddollar count: " + playercontroller.sanddollarCount);
    }
}
