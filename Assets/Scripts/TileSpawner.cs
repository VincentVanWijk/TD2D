using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour 
{
	public GameObject tile, obstacle;
	public int levelWidth, levelHeight;

	void Start () 
	{
		SpawnTiles ();
		SpawnObstacles ();

	}
	
	void Update () 
	{
		
	}

	void SpawnTiles()
	{
//		GameObject parentTile = GameObject.FindGameObjectWithTag ("Parent Tile");
//		int z = 0;
//
//		for (int x = 0; x < levelWidth; x++) 
//		{
//			for (int y = 0; y < levelHeight; y++) 
//			{
//				Vector3 spawnPos = new Vector3(x + 0.5f, y + 0.5f, z);
//				GameObject currentTile = Instantiate (tile, spawnPos, Quaternion.identity) as GameObject;
//				currentTile.name = "Tile " + x + ", " + y + ", " + z;
//				currentTile.transform.SetParent (parentTile.transform);
//			}
//		}
	}

	void SpawnObstacles()
	{
		GameObject parentObstacle = GameObject.FindGameObjectWithTag ("Parent Obstacle");
		int x = 10;
		int maxy = 16;
		int z = 0;
		for (int y = 0; y < maxy; y++) 
		{
		
			Vector3 spawnPos = new Vector3 (x + 0.5f, y + 0.5f, z);
			GameObject currentObstacle =  Instantiate (obstacle, spawnPos, Quaternion.identity) as GameObject;
			currentObstacle.transform.SetParent (parentObstacle.transform);
		}

		AstarPath.active.Scan ();
	}
}

