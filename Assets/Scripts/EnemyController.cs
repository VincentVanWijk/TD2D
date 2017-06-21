using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	public int health, damage, level;
	public bool isAlive;
	public Sprite deadEnemy;
	public GameObject blood;
	

	void Start () 
	{
		isAlive = true;
		FindEndPoint ();
	}
	
	void Update () 
	{
	}

	void FindEndPoint()
	{
		GameObject endPoint = GameObject.FindGameObjectWithTag ("End Point");

		AIPath pathFinder = gameObject.GetComponent<AIPath> ();
		pathFinder.target = endPoint.transform;
	}

	public void ReceiveDamage(int recievedDamage)
	{
		health -= recievedDamage;
		GameObject b = Instantiate (blood, transform.position, Quaternion.identity) as GameObject;
		Destroy (b, 2);
		CheckHealth ();
	}

	void CheckHealth()
	{
		if (health <= 0) 
		{
			Die ();
		}
	}

	void Die()
	{
		gameObject.GetComponent<Animator> ().enabled = false;
		SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();
		renderer.sprite = deadEnemy;
		renderer.sortingLayerName = "DeadEnemy";

		gameObject.GetComponent<AIPath> ().speed = 0;
		isAlive = false;
		Destroy (gameObject, 2);
	}

}
