using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour 
{
	[SerializeField] EnemyStrats enemyStats;
	[SerializeField] int currentHealth;

	// Use this for initialization
	void Start () 
	{
		GetComponent<NavMeshAgent>().speed = enemyStats.speed;
		currentHealth = enemyStats.health;
	}
	
	public void Health(int damage)
	{
		currentHealth-= damage;
		if(currentHealth <= 0)
		{
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision c) {
		if(c.gameObject.GetComponent<TempleStats>()) {
			HurtTemple(c.gameObject.GetComponent<TempleStats>());
		}
	}

	void HurtTemple(TempleStats temple) {
		temple.health -= enemyStats.health;
		temple.CheckHealth();
	}
}
