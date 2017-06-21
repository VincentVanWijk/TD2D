using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
	public GameObject wall, smgTower;
	void Start () 
	{
		
	}
	
	void Update () 
	{
		
	}

	void OnMouseEnter()
	{
		if (gameObject.layer != 9 && GameController.isSpawningObject) 
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
			
		
			switch (GameController.towerToSpawn) 
			{
				case TowerType.Wall:
					Instantiate (wall, transform.position, Quaternion.identity);
					break;
				
				case TowerType.SMGTower:
					Instantiate (smgTower, transform.position, Quaternion.identity);
					break;
					
				default:
					break;
			}
		}

		//GameController.isSpawningObject = false;

	}
}
