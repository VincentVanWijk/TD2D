using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour 
{

	void Start () 
	{
		
	}
	
	void Update () 
	{
		if (transform.hasChanged)
		{
			transform.hasChanged = false;
			AstarPath.active.UpdateGraphs (gameObject.GetComponent<BoxCollider2D>().bounds);
		}
	}
}
