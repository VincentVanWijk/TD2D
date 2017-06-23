using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour 
{
	public int damage,  health, level, range;
	public float fireRate;
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
				closest = enemy;
				distance = curDistance;
			}
		}
		return closest;		
	}
}
