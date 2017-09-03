using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TowerType
{
	Wall,
	SMGTower,
}

public class TowerSpawnController : MonoBehaviour 
{
	public TowerType towerToSpawn;

	public void StartSpawn()
	{
		GameController.towerToSpawn = towerToSpawn;
		GameController.isSpawningObject = true;
		GameController.HideTowerSpawnPanel ();
	}

	public void CancelSpawn()
	{
		GameController.isSpawningObject = false;
		GameController.ShowTowerSpawnPanel ();
	}
}
