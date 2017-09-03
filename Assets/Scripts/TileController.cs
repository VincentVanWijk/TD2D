using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
	public GameObject wall, smgTower;

	void OnMouseEnter()
	{
		if (GameController.isSpawningObject) 
		{
			GetComponent<SpriteRenderer> ().color = Color.green;
		} 
	}

	void OnMouseExit()
	{
		GetComponent<SpriteRenderer> ().color = Color.white;
	}

	void OnMouseDown()
	{
		GameObject objectToSpawn;
		if (GameController.isSpawningObject) 
		{
			GameObject spawnedObject = null;
			GameObject parentObject = GameObject.FindGameObjectWithTag ("ParentBuiltTowers");
			switch (GameController.towerToSpawn) 
			{
			case TowerType.Wall:

				objectToSpawn = wall;
				/*
				if (GameController.money >= wall.GetComponent<TowerController>().cost ) 
				{
					spawnedObject = Instantiate (wall, transform.position, Quaternion.identity) as GameObject;
					GameController.money -= wall.GetComponent<TowerController> ().cost;
					spawnedObject.transform.parent = parentObject.transform;
				}	
				*/
				break;
				
			case TowerType.SMGTower:

				objectToSpawn = smgTower;
				/*if (GameController.money >= smgTower.GetComponent<TowerController> ().cost) {
					spawnedObject = Instantiate (smgTower, transform.position, Quaternion.identity) as GameObject;
					GameController.money -= smgTower.GetComponent<TowerController> ().cost;
					spawnedObject.transform.parent = parentObject.transform;

				}*/
				break;
					
			default:

				objectToSpawn = wall;
					break;
			}


			if(GameController.money >= objectToSpawn.GetComponent<TowerController>().cost)
			{
				spawnedObject = Instantiate (objectToSpawn, transform.position, Quaternion.identity) as GameObject;
				GameController.money -= objectToSpawn.GetComponent<TowerController> ().cost;
				spawnedObject.transform.parent = parentObject.transform;
			}

		}
	}
}
