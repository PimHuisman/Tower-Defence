using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviour : MonoBehaviour
{
	[SerializeField] int unitMaxAmount;
	[SerializeField] Transform unit;
	public List<Transform> unitsList = new List<Transform>();
	[SerializeField] Transform spawnPos;
	public Transform target;
	[SerializeField] int newAmount;
	[SerializeField] float timerNewUnit;

	[Header("Path")]
	[SerializeField] TowerStat stats;
	[SerializeField] LayerMask pathMask;
	[SerializeField] float radius;
	void Start () 
	{
		CreateUnits(unitMaxAmount);
		StartCoroutine("NewEnemy");
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
			unitsList.Add(newUnit);
			Vector3 newPos =  new Vector3(target.position.x, target.position.y, target.position.z);
			newUnit.GetComponent<Units>().target = target;
			newUnit.SetParent(spawnPos);
		}
	}

	public void RemoveUnit(Transform deadUnit)
	{
		unitsList.Remove(deadUnit);
	}
}
