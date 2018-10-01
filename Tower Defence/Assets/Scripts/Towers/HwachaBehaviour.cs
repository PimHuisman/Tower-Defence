using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HwachaBehaviour : MonoBehaviour 
{
	[Header("Arrows")]
	public List<Transform> arrowList = new List<Transform>();
	[SerializeField] float spacingY;
	[SerializeField] float spacingZ;
	[SerializeField] Vector3 mapsize;
	[SerializeField] Transform arrowPos;
	[SerializeField] Transform arrowObject;
	[SerializeField] TowerStat stats;
	int addForce;
	public List<Transform> targets = new List<Transform>();
	[SerializeField]bool lockTarget;
	[SerializeField] GameObject arrow;
	[SerializeField] float fireCountdown;
	float fireRate;
	[SerializeField] Transform weapon;

	void Start () 
	{
		//GenerateArrows();
		StartCoroutine(Timer());
		addForce = stats.addForce;
		arrow = stats.ammo;
		fireRate = stats.fireRate;
	}
	void Update() 
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
	}
	void Shoot()
	{
		GenerateArrows();
		for (int i = 0; i < arrowList.Count; i++)
		{
			
		}
	}

    void GenerateArrows()
    {
        for (int y = 0; y < mapsize.y; y++)
        {
            for (int z = 0; z < mapsize.z; z++)
            {
				float testX = arrowPos.position.x;
				float testY = arrowPos.position.y + spacingY *y;
				float testZ = arrowPos.position.z + -spacingZ *z;

                Vector3 newArroPos = new Vector3(testX, testY, testZ);
                Transform arrow = Instantiate(arrowObject, newArroPos, arrowPos.rotation,arrowPos.transform) as Transform;
				//arrow.transform.parent = arrowPos.transform;
				arrowList.Add(arrow);
            }
        }
    }
	IEnumerator Timer()
	{
		yield return new WaitForSeconds(0);

		while (lockTarget)
		{
			Shoot();
        	yield return new WaitForSeconds(3);
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

	void OnTriggerEnter(Collider other) 
	{
		if (other.transform.tag == "Enemy")
		{
			lockTarget = true;
			targets.Add(other.transform);
		}
	}
	void OnTriggerStay(Collider other) 
	{

		if (other.transform.tag == "Enemy")
		{
			Vector3 lead = new Vector3(targets[0].position.x, weapon.transform.position.y, targets[0].position.z);
			weapon.transform.LookAt(lead);
		}
	}

	void OnTriggerExit(Collider other) 
	{
		if (other.transform.tag == "Enemy")
		{
			targets.Remove(other.transform);
			weapon.LookAt(null);
			CheckEnemies();
		}
	}
}
