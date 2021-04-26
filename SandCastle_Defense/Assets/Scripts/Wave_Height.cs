using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Height : MonoBehaviour
{
    public GameObject timer;
    public Material Mat_Ocean;
    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("TimeText");

    }

    // Update is called once per frame
    void Update()
    {
        Timer newtimer = timer.GetComponent<Timer>();
        float curr_height = 0.9f;

        if (newtimer.timeLeft < 3f && (newtimer.timeLeft > 0f))
        {
            curr_height = 0.58f;
            Mat_Ocean.SetFloat("_Height1", curr_height);


        }
        else
        {
            curr_height = 0.9f;
            Mat_Ocean.SetFloat("_Height1", curr_height);
        }
    }
}
