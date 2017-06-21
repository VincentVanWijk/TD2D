using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public float speed;

	[HideInInspector]
		public int damage;
	[HideInInspector]
		public EnemyController enemyController;
	[HideInInspector]
		public GameObject target;

	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		FlyToTarget ();

	}

	public void FlyToTarget()
	{
		if (target) 
		{
			transform.position = Vector2.MoveTowards (transform.position, target.transform.position, speed * Time.deltaTime);
			if (Vector2.Distance(transform.position,target.transform.position) < 0.01f) 
			{
				if(enemyController)
				{
					enemyController.ReceiveDamage (damage);
				}
				Destroy (gameObject);
			}
		}
		else 
		{
			Destroy (gameObject);
		}
	}

	public void setEnemy(GameObject enemy)
	{
		enemyController = enemy.GetComponent<EnemyController> ();
	}
}
