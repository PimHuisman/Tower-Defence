using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour 
{
	Transform target;
	public int health;
	public int currentHealth;

	void Start() 
	{
		currentHealth = health;
	}

	void Update() 
	{
		//CheckHealth();
	}

	void CheckHealth(int damage)
	{
		currentHealth -= damage;
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
