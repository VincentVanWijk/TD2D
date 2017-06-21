using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour 
{
	public GameObject[] enemies;
	int maxEnemyCount;

	void Start () 
	{
	}
	
	void Update ()
	{
		
	}

	public void SpawnEnemies()
	{
		int maxEnemyCount = GameController.waveNumber * 10;
		int currentEnemyCount = 0;

		while (currentEnemyCount < maxEnemyCount) 
		{
			int random = Random.Range (0, enemies.Length);
			GameObject spawnedEnemy =  Instantiate (enemies[random], transform.position, Quaternion.identity) as GameObject;
			currentEnemyCount += spawnedEnemy.GetComponent<EnemyController> ().level;
		}
	}
}
