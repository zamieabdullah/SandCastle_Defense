using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Trench : MonoBehaviour
{
	public Tilemap tilemapColliders;
    public RuleTile trenchRuleTileDry;
    public RuleTile trenchRuleTileWet;

    public float trench_dig_count = 1;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trench_dig_count == 2)
        {
            DoubleTrench();
        }
    }

    

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("trench"))
		{ 
            Debug.Log("double trench!!!");
			DoubleTrench();
		}

        //if (gameObject.transform.position == ......)

        if(other.gameObject.CompareTag("wave"))
        {
            if (gameObject.tag == "wetTrench")
            {
                Destroy(gameObject); 
            }
            else  // trench or doubleTrench
            {
                FillWithWater();
            }

            

        }
	}

    void DoubleTrench()
    {
        // make trench sprite darker
        gameObject.GetComponent<SpriteRenderer>().color = new Color (71, 65, 59, 100);
        

        gameObject.tag = "doubleTrench";
        // tag it so in the crab script, crab gets trapped by it

    }

    void FillWithWater()
    {
        Vector3Int currCell = tilemapColliders.WorldToCell(transform.position);
        tilemapColliders.SetTile(currCell, trenchRuleTileWet); // WET TILE
    }
}
