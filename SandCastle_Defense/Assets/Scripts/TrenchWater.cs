using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TrenchWater : MonoBehaviour
{
	public Tilemap tilemapColliders;
    public RuleTile trenchRuleTileDry;
    public RuleTile trenchRuleTileWet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("crab"))
		{
			Debug.Log("crabbbbb");
			Water();
		}
	}

    void Water()
    {
        Vector3Int currCell = tilemapColliders.WorldToCell(transform.position);

        // replace the tile there with trenchRuleTile
        tilemapColliders.SetTile(currCell, trenchRuleTileWet);
    }
}
