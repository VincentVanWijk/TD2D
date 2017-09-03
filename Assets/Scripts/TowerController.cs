using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour 
{
	public int damage,  health, level, range, cost;
	public float fireRate, rotateSpeed;
	public GameObject bullet;


	void Start () 
	{
		AstarPath.active.UpdateGraphs (gameObject.GetComponent<BoxCollider2D>().bounds);

		if (bullet) 
		{
			InvokeRepeating ("Shoot", fireRate, fireRate);
		}
	}

	void Shoot()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		GameObject enemy = FindClosestEnemy (enemies);
		if (enemy && enemy.GetComponent<EnemyController>().isAlive) 
		{
			GameObject b = Instantiate (bullet, transform.position, Quaternion.identity) as GameObject;
			BulletController bulletController = b.GetComponent<BulletController> ();
			bulletController.damage = damage;
			bulletController.setEnemy(enemy);
			bulletController.target = enemy;

			if (gameObject.transform.childCount > 0) 
			{
				Transform pivot = gameObject.transform.GetChild (0);

				pivot.transform.LookAt (enemy.transform.position);

				Quaternion q = pivot.transform.rotation;
				Vector3 newRot = q.eulerAngles;
				newRot.z = 90;
				q.eulerAngles = newRot;
				pivot.transform.rotation = q;
//				
				float thisIsX = q.eulerAngles.x;
				float thisIsZ = 90 - thisIsX;

				print (thisIsZ);

				Quaternion q2 = b.transform.rotation;
				Vector3 newRotB = Vector3.zero;
				newRotB.z = thisIsZ;
				q2.eulerAngles = newRotB;
				b.transform.rotation = q2;
//				iTween.LookTo(pivot.gameObject, 
//					iTween.Hash
//					(
//						"looktarget", enemy.transform.position,
//						"time", rotateSpeed,
//						"easetype", iTween.EaseType.linear
//					));
			}


		}
	}

	public GameObject FindClosestEnemy(GameObject[] enemies) 
	{
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject enemy in enemies) 
		{
			Vector3 diff = enemy.transform.position - position;
			float curDistance = diff.magnitude;

			if (curDistance < distance && curDistance <= range) 
			{
				if (enemy.GetComponent<EnemyController>().isAlive) 
				{
					closest = enemy;
					distance = curDistance;	
				}
			}
		}
		return closest;		
	}
}
