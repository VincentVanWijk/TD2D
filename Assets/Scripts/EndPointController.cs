using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointController : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") 
		{
			if (GameController.playerHealth > 0) 
			{
				EnemyController enemy = other.GetComponent<EnemyController> ();
				GameController.playerHealth -= enemy.damage;
				GameController.UpdateUI ();

				if (GameController.playerHealth <= 0) 
				{
					GameController.ShowGameOverScreen ();
					Time.timeScale = 0;
				}
			}
			Destroy (other.gameObject);
		}
	}
}
