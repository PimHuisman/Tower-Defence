using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPath : MonoBehaviour 
{
	Vector3 target;
	NavMeshAgent agent;
	

	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
		target = GameObject.FindGameObjectWithTag("EndPoint").transform.position;
	}
	
	void Update () 
	{
		agent.SetDestination(target);
	}
}
