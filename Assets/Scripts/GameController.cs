using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameController : MonoBehaviour
{

	public static int playerHealth, maxHealth, money, waveNumber;
	public static bool isSpawningObject;
	public static TowerType towerToSpawn = TowerType.Wall;
	public static Text playerHealthText; 
	public Text waveButton; 
	GameObject enemySpawner;


	// Use this for initialization
	void Start () 
	{
		isSpawningObject = false;
		playerHealthText = GameObject.FindGameObjectWithTag("Player Health Text").GetComponent<Text>();
		enemySpawner = GameObject.FindGameObjectWithTag ("Enemy Spawner");

		maxHealth = 10;
		waveNumber = 0;
		playerHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerHealthText.text = playerHealth.ToString();
	}

	public void StartWave()
	{
		waveNumber++;
		enemySpawner.GetComponent<EnemySpawnController> ().SpawnEnemies ();
		waveButton.text = "Wave: " + waveNumber;
	}


}
