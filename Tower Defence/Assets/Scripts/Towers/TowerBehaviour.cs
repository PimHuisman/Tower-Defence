using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour 
{
	[SerializeField] TowerStat stats;
	int addForce;
	public List<Transform> targets = new List<Transform>();
	bool lockTarget;
	GameObject bullet;
	[SerializeField] float fireCountdown;
	float fireRate;
	[SerializeField] Transform firePoint;
	[Header("Random Offset")]
	float xOffset;
	[SerializeField] float xOffsetMin;
	[SerializeField] float xOffsetMax;
	float yOffset;
	[SerializeField] float yOffsetMin;
	[SerializeField] float yOffsetMax;
	float zOffset;
	[SerializeField] float zOffsetMin;
	[SerializeField] float zOffsetMax;



	void Start () 
	{
		addForce = stats.addForce;
		bullet = stats.ammo;
		fireRate = stats.fireRate;
	}
	
	void Update () 
	{
		CheckEnemies();
		if (lockTarget)
		{
			if (fireCountdown <=0)
			{
				xOffset = Random.Range(xOffsetMin, xOffsetMax);
				yOffset = Random.Range(yOffsetMin, yOffsetMax);
				zOffset = Random.Range(zOffsetMin, zOffsetMax);
				Shoot();
				fireCountdown = 1f/fireRate;
			}
			fireCountdown -= Time.deltaTime;
		}
	}
	void CheckEnemies()
	{
		for (int i = 0; i < targets.Count; i++)
		{
			if (targets[i] == null)
			{
				targets.Remove(targets[i]);
				lockTarget = false;
			}
		}
	}

	void Shoot()
	{
		GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
		Rigidbody rigBullet = newBullet.GetComponent<Rigidbody>();
		rigBullet.AddForce(firePoint.forward * addForce);
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.transform.tag == "Enemy")
		{
			lockTarget = true;
			targets.Add(other.transform);
			print("Enemy is detected");
		}
	}
	void OnTriggerStay(Collider other) 
	{

		if (other.transform.tag == "Enemy")
		{
			Vector3 lead = new Vector3(targets[0].transform.position.x + xOffset, transform.position.y + yOffset, targets[0].transform.position.z + zOffset);
			firePoint.LookAt(lead);
		}
	}

	void OnTriggerExit(Collider other) 
	{
		if (other.transform.tag == "Enemy")
		{
			lockTarget = false;
			targets.Remove(other.transform);
			firePoint.LookAt(null);
			print("Enemy got away");
		}
	}
}
