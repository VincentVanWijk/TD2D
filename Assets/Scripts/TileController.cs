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
		if (GameController.isSpawningObject) 
		{
			GameObject spawnedObject = null;
			GameObject parentObject = GameObject.FindGameObjectWithTag ("ParentBuiltTowers");
			switch (GameController.towerToSpawn) 
			{
				case TowerType.Wall:
					spawnedObject = Instantiate (wall, transform.position, Quaternion.identity) as GameObject;
					break;
				
				case TowerType.SMGTower:
					spawnedObject = Instantiate (smgTower, transform.position, Quaternion.identity) as GameObject;
					break;
					
				default:
					break;
			}

			spawnedObject.transform.parent = parentObject.transform;
		}
	}
}
