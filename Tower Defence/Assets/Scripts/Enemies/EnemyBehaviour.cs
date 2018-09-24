using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour 
{
	[SerializeField] EnemyStrats enemystats;
	[SerializeField] int currentHealth;

	// Use this for initialization
	void Start () 
	{
		GetComponent<NavMeshAgent>().speed = enemystats.speed;
		currentHealth = enemystats.health;
	}
	
	public void Health(int damage)
	{
		currentHealth-= damage;
		if(currentHealth <= 0)
		{
			Destroy(gameObject);
		}
	}

	void Attack() {
		
	}
}
