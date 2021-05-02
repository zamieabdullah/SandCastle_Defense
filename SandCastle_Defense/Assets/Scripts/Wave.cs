using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public GameObject centerTower;
    private Vector3 target;

    private float speed = 1;


    // Start is called before the first frame update
    void Start()
    {
        target = centerTower.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("waveBlocker")) //NOT REGISTERING COLLISION, IDK WHY
        {
            Debug.Log("hit waveblocker");
            speed = 0f;
        }
    }
}
