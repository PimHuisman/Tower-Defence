using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour 
{
	[SerializeField] TowerStat stats;
	List<Transform> targets = new List<Transform>();


	void Start () 
	{

	}
	
	void Update () 
	{
		
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.transform.tag == "Enemy")
		{
			targets.Add(other.transform);
			print("Enemy is detected");
		}
	}

	void OnTriggerExit(Collider other) 
	{
		if (other.transform.tag == "Enemy")
		{
			targets.Remove(other.transform);
			print("Enemy got away");
		}
	}
}
