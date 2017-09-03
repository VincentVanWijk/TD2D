using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour 
{
	public float speed;

	[HideInInspector]
		public int damage;
	[HideInInspector]
		public EnemyController enemyController;
	[HideInInspector]
		public GameObject target;
	
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
			Transform pivot = gameObject.transform;

//			pivot.transform.LookAt (target.transform.position);
//
//			Quaternion q = pivot.transform.rotation;
//			Vector3 newRot = q.eulerAngles;
//			newRot.z = 90;
//			q.eulerAngles = newRot;
//			pivot.transform.rotation = q;
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
