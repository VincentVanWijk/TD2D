using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerToggleController : MonoBehaviour
{

	public void SetWallTower()
	{
		GameController.towerToSpawn = TowerType.Wall;
	}

	public void SetSMGTower()
	{
		GameController.towerToSpawn = TowerType.SMGTower;
	}
}
