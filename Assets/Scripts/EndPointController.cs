using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointController : MonoBehaviour
{
	public GameObject gameOverScreen;
	void Start () 
	{
		
	}
	
	void Update ()
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") 
		{
			if (GameController.playerHealth > 0) 
			{
				GameController.playerHealth--;

				if (GameController.playerHealth <= 0) 
				{
					gameOverScreen.SetActive (true);
					Time.timeScale = 0;
				}
			}
			Destroy (other.gameObject);
		}
	}
}
