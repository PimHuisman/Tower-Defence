using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour 
{
	[SerializeField] int damage;

	void OnCollisionEnter(Collision other) 
	{
		if (other.transform.tag == "Enemy")
		{
			other.transform.GetComponent<EnemyBehaviour>().Health(damage);
		}
	}
}
