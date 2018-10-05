using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Units : MonoBehaviour 
{
	NavMeshAgent agent;
	[HideInInspector] public Transform target;
	public int health;
	public int currentHealth;

	void Start() 
	{
		agent = GetComponent<NavMeshAgent>();
		currentHealth = health;
	}

	void Update() 
	{
		SetPosition();
	}

	void SetPosition()
	{
		agent.SetDestination(target.position);
	}

	public void CalculateHealth(int damage)
	{
		currentHealth -= damage;
		if(currentHealth <= 0)
		{
			currentHealth = 0;
			gameObject.GetComponentInParent<UnitBehaviour>().RemoveUnit(transform);
			Destroy(gameObject);
		}
		// Check if your health is zero.
		// If it is zero say to your tower remove me.
	}

	void OnTriggerEnter(Collider other) 
	{
		// When enemy enters radius set it == to target.
	}

	IEnumerator AttackRate()
	{

		yield return new WaitForSeconds(0);
	}

}
