using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public static GameController gameController;
	public GameObject cancelSpawnButton, towerButtonPanel, gameOverScreen;
	public EnemySpawnController enemySpawner;
	public static int playerHealth, maxHealth, money, waveNumber;
	public static bool isSpawningObject;
	public static TowerType towerToSpawn = TowerType.Wall;
	public Text playerHealthText, waveButtonText, moneyText; 

	void Awake()
	{
		gameController = this;
	}
	// Use this for initialization
	void Start () 
	{
		isSpawningObject = false;
		maxHealth = 10;
		waveNumber = 0;
		money = 350;
		playerHealth = maxHealth;
	}

	void Update()
	{
		UpdateUI ();
	}

	public void StartWave()
	{
		waveNumber++;
		enemySpawner.SpawnEnemies ();
	}

	public static void UpdateUI()
	{
		gameController.playerHealthText.text = "Lives: " + playerHealth;
		gameController.waveButtonText.text = "Wave: " + waveNumber;
		gameController.moneyText.text = "$: " + money;
	}

	public static void HideTowerSpawnPanel()
	{
		gameController.cancelSpawnButton.SetActive (true);
		gameController.towerButtonPanel.SetActive (false);
	}

	public static void ShowTowerSpawnPanel()
	{
		gameController.cancelSpawnButton.SetActive (false);
		gameController.towerButtonPanel.SetActive (true);
	}

	public static void ShowGameOverScreen()
	{
		gameController.gameOverScreen.SetActive (true);
	}

	public static void HideGameOverScreen()
	{
		gameController.gameOverScreen.SetActive (false);
	}

	public void ResetLevel()
	{
		maxHealth = 10;
		waveNumber = 0;
		money = 350;
		RemoveSpawnedObstacles ();
		KillAllEnemies ();
		HideGameOverScreen ();
		UpdateUI ();
		Time.timeScale = 1;
	}

	public void RemoveSpawnedObstacles()
	{
		GameObject playerBuiltTowers = GameObject.FindGameObjectWithTag("ParentBuiltTowers");

		foreach (Transform child in playerBuiltTowers.transform) 
		{
			Destroy (child.gameObject);	
		}
	}

	public void KillAllEnemies()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

		foreach (GameObject enemy in enemies) 
		{
			Destroy (enemy);	
		}
	}

}
