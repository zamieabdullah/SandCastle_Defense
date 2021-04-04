﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabMovement : MonoBehaviour
{
 	private Vector3 target = new Vector3(0, 2, 0);
 	private float speed = 1;
    // float wiggleDistance = 1;
    // float wiggleSpeed = 5;

    private void Start()
    {
		SpawnCrab();
    }

    void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

	    // float xPosition = Mathf.Sin(Time.time * wiggleSpeed) * wiggleDistance;

	    // transform.localPosition = new Vector3(xPosition, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.CompareTag("beachshovel"))
		{
			target *= -2;
		}
		
	}

	void SpawnCrab()
    {
		Vector2 crabPos = new Vector2(Random.Range(-20f, 20f), -5f);

		transform.position = crabPos;
    }

}