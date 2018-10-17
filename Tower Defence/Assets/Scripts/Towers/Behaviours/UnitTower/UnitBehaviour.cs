using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviour : MonoBehaviour
{
	public List<Transform> unitsList = new List<Transform>();
	[SerializeField] Transform unit;
	[SerializeField] int unitMaxAmount;
	[SerializeField] Transform spawnPos;
	[SerializeField] Transform target;
	[SerializeField] int newAmount;
	[SerializeField] float timerNewUnit;

	[Header("Path")]
	[SerializeField] TowerStat stats;
	[SerializeField] LayerMask pathMask;
	[SerializeField] float radius;
	void Start () 
	{
		StartCoroutine("NewEnemy");
		CreateUnits(unitMaxAmount);
		radius = stats.range;
	}
	
	void Update () 
	{
		CheckUnits();
	}

	void CheckUnits()
	{
		if (unitsList.Count < unitMaxAmount)
		{
			newAmount = unitMaxAmount - unitsList.Count;
		}
	}

	void CheckPath()
	{
		 Collider[] closestPath = Physics.OverlapSphere(transform.position, radius, pathMask);


	}
	IEnumerator NewEnemy()
	{
		while (true)
        {
            while (unitsList.Count < unitMaxAmount)
            {
                yield return new WaitForSeconds(timerNewUnit);
                CreateUnits(newAmount);
            }
            yield return null;
        }
	}

	void CreateUnits(int x)
	{
		// Create enemies at pos.
		for (int i = 0; i < x; i++)
		{
			Transform newUnit = Instantiate(unit, spawnPos.position, spawnPos.rotation);
			Vector3 newPos =  new Vector3(target.position.x, target.position.y, target.position.z);
			newUnit.GetComponent<Units>().target = target;
			newUnit.SetParent(spawnPos);
			unitsList.Add(newUnit);
		}
	}

	public void RemoveUnit(Transform deadUnit)
	{
		unitsList.Remove(deadUnit);
	}
}
