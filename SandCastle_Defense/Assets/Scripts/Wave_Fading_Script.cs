using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave_Fading_Script : MonoBehaviour
{
    public Material Mat_WaveProjectile1;
    private float curr_visibility;

    private float speed = 1.3f;
    // Start is called before the first frame update
    void Start()
    {

        curr_visibility = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= -1f)
        {
            //Debug.Log("We will now start fading");
            curr_visibility -= Time.deltaTime * speed;
            if (curr_visibility > 0f)
            {
                //Debug.Log("visibility is decreasing");
                Mat_WaveProjectile1.SetFloat("_Visibility", curr_visibility);
            }
        }
    }
}
