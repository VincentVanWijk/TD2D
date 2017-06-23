using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour 
{
	public GameObject[] enemies;
	public float spawnRate;
	int maxEnemyCount;

	public void SpawnEnemies()
	{
		StartCoroutine (HandleIt(spawnRate));
	}

	private IEnumerator HandleIt(float spawnRate)
	{
		int maxEnemyCount = GameController.waveNumber * 4;
		int currentEnemyCount = 0;

		while (currentEnemyCount < maxEnemyCount) 
		{
			int random;
			if (maxEnemyCount - currentEnemyCount > enemies.Length -1) 
			{
				random = Random.Range (0, enemies.Length);
			} 
			else 
			{
				random = Random.Range (0, maxEnemyCount - currentEnemyCount);		
			}
			GameObject spawnedEnemy =  Instantiate (enemies[random], transform.position, Quaternion.identity) as GameObject;
			currentEnemyCount += spawnedEnemy.GetComponent<EnemyController> ().spawnWeight;
			yield return new WaitForSeconds( spawnRate);

		}
	}
}
