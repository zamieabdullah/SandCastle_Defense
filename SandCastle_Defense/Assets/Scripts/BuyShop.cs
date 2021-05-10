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

    static public bool shovelpurchased;
    static public bool crabcatcherpurchased;
    static public bool bucketpurchased;

    private AudioSource canbuyAudio;
    private AudioSource cantbuyAudio;

    private void Start()
    {
        shovelpurchased = false;
        crabcatcherpurchased = false;
        bucketpurchased = false;
        AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
        canbuyAudio = allMyAudioSources[0];
        cantbuyAudio = allMyAudioSources[1];

    }

    public void purchaseShovel()
    {
        if(shovelpurchased == false)
        {
            Debug.Log("BUYING SHOVEL " + playercontroller.sanddollarCount);
            if (playercontroller.sanddollarCount > 2)
            {
                canbuyAudio.Play();
                playercontroller.sanddollarCount = playercontroller.sanddollarCount - 3;
                playercontroller.SetSanddollarCountText();

                GameObject a = Instantiate(item) as GameObject;
                a.transform.position = new Vector2(6.92f, 5.79f);
                a.transform.SetParent(parent.transform);
                feedbackText.color = Color.green;
                feedbackText.text = "Successful Purchase!";

                shovelpurchased = true;
            }
            else
            {
                cantbuyAudio.Play();
                feedbackText.color = Color.red;
                feedbackText.text = "Get more sand dollars!";
                Debug.Log("CANNOT BUY!!! Collect sand dollars");
            }
            Debug.Log("New sanddollar count: " + playercontroller.sanddollarCount);

        } else
        {
            cantbuyAudio.Play();
            feedbackText.color = Color.red;
            feedbackText.text = "Can only have one shovel!";
        }
    }

    public void purchaseCrabcatcher()
    {
        if (crabcatcherpurchased == false)
        {
            Debug.Log("BUYING CRAB CATCHER " + playercontroller.sanddollarCount);
            if (playercontroller.sanddollarCount > 2)
            {
                canbuyAudio.Play();
                playercontroller.sanddollarCount = playercontroller.sanddollarCount - 3;
                playercontroller.SetSanddollarCountText();

                GameObject a = Instantiate(item) as GameObject;
                a.transform.position = new Vector2(6.92f, 4.2f);
                a.transform.SetParent(parent.transform);
                feedbackText.color = Color.green;
                feedbackText.text = "Successful Purchase!";

                crabcatcherpurchased = true;
            }
            else
            {
                cantbuyAudio.Play();
                feedbackText.color = Color.red;
                feedbackText.text = "Get more sand dollars!";
                Debug.Log("CANNOT BUY!!! Collect sand dollars");
            }
            Debug.Log("New sanddollar count: " + playercontroller.sanddollarCount);
        }
        else
        {
            cantbuyAudio.Play();
            feedbackText.color = Color.red;
            feedbackText.text = "Can only have one crab catcher!";
        }
    }

    public void purchaseBucket()
    {
        if(bucketpurchased == false)
        {
            Debug.Log("BUYING BUCKET " + playercontroller.sanddollarCount);
            if (playercontroller.sanddollarCount > 2)
            {
                canbuyAudio.Play();
                playercontroller.sanddollarCount = playercontroller.sanddollarCount - 3;
                playercontroller.SetSanddollarCountText();

                GameObject a = Instantiate(item) as GameObject;
                a.transform.position = new Vector2(6.92f, 2.8f);
                a.transform.SetParent(parent.transform);
                feedbackText.color = Color.green;
                feedbackText.text = "Successful Purchase!";

                bucketpurchased = true;
            }
            else
            {
                cantbuyAudio.Play();
                feedbackText.color = Color.red;
                feedbackText.text = "Get more sand dollars!";
                Debug.Log("CANNOT BUY!!! Collect sand dollars");
            }
            Debug.Log("New sanddollar count: " + playercontroller.sanddollarCount);
        } else
        {
            cantbuyAudio.Play();
            feedbackText.color = Color.red;
            feedbackText.text = "Can only have one bucket!";
        }
    }

    public void upgradeShovel()
    {
        Debug.Log("upgrading shovel");
        if (playercontroller.sanddollarCount > 49)
        {
            canbuyAudio.Play();
            playercontroller.sanddollarCount = playercontroller.sanddollarCount - 50;
            playercontroller.SetSanddollarCountText();

            //CODE to change shovel to upgraded
            playercontroller.has_upgraded_shovel = true;
            if (playercontroller.digs_left > 0)
            {
                int additional_digs = 10 - playercontroller.digs_left;
                playercontroller.digs_left += additional_digs;
                playercontroller.SetDigsLeftCountText();
            }

            GetComponent<Button>().interactable = false;
            feedbackText.color = Color.green;
            feedbackText.text = "Successfully Upgraded!";
        }
        else
        {
            cantbuyAudio.Play();
            feedbackText.color = Color.red;
            feedbackText.text = "Get more sand dollars!";
            Debug.Log("CANNOT UPGRADE! Collect sand dollars");
        }
        Debug.Log("New sanddollar count: " + playercontroller.sanddollarCount);
    }

    public void upgradeCrabCatcher()
    {
        Debug.Log("upgrading crabcatcher");
        if (playercontroller.sanddollarCount > 49)
        {
            canbuyAudio.Play();
            playercontroller.sanddollarCount = playercontroller.sanddollarCount - 50;
            playercontroller.SetSanddollarCountText();

            //CODE to change crabcatcher to upgraded
            playercontroller.has_upgraded_catcher = true;

            GetComponent<Button>().interactable = false;
            feedbackText.color = Color.green;
            feedbackText.text = "Successfully Upgraded!";
        }
        else
        {
            cantbuyAudio.Play();
            feedbackText.color = Color.red;
            feedbackText.text = "Get more sand dollars!";
            Debug.Log("CANNOT UPGRADE! Collect sand dollars");
        }
        Debug.Log("New sanddollar count: " + playercontroller.sanddollarCount);
    }

    public void upgradeBucket()
    {
        Debug.Log("upgrading bucket");
        if (playercontroller.sanddollarCount > 49)
        {
            canbuyAudio.Play();
            playercontroller.sanddollarCount = playercontroller.sanddollarCount - 50;
            playercontroller.SetSanddollarCountText();

            //CODE to change bucket to upgraded
            playercontroller.has_upgraded_bucket = true;

            GetComponent<Button>().interactable = false;
            feedbackText.color = Color.green;
            feedbackText.text = "Successfully Upgraded!";
        }
        else
        {
            cantbuyAudio.Play();
            feedbackText.color = Color.red;
            feedbackText.text = "Get more sand dollars!";
            Debug.Log("CANNOT UPGRADE! Collect sand dollars");
        }
        Debug.Log("New sanddollar count: " + playercontroller.sanddollarCount);
    }
}
