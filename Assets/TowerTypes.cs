using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerType
{
	Wall,
	SMGTower,
}

public class TowerTypes : MonoBehaviour {

	public TowerType towerToSpawn;

	public void StartSpawn()
	{
		GameController.towerToSpawn = towerToSpawn;
		GameController.isSpawningObject = !GameController.isSpawningObject;
	}
}
