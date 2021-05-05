using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player; // reference to player object
    private Vector3 offset; // distance we want to maintain from the player
    private Vector2 player_prev_position;
    private Vector3 cameraPos = new Vector3();

	void Start()
	{ 
		cameraPos.y = this.transform.position.y;
	}

	// LateUpdate is called after all other Scene Object scripts finish their Updates
	void LateUpdate()
	{
        
		if (Vector2.Distance(player.transform.position, transform.position) > 12)
		{
			Vector2 delta_position;
			delta_position = (Vector2)player.transform.position - player_prev_position;
			delta_position.y = cameraPos.y;
			transform.Translate(delta_position);
		}
		player_prev_position = player.transform.position;

    }
}
