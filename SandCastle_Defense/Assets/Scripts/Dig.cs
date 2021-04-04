using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Dig : MonoBehaviour
{
	
    public Tilemap tilemap;
    public GameObject player;

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            //print("space key was pressed");
        	DigTrench();
        }
    }

    void DigTrench()
    {
        // get current grid location
        Vector3Int currCell = tilemap.WorldToCell(player.transform.position);

        // delete the tile there
        tilemap.SetTile(currCell, null);

    }
}
