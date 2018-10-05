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
	[SerializeField] float timer;
	[SerializeField] float timerNewUnit;
	void Start () 
	{
		CreateUnits();
	}
	
	void Update () 
	{
		
	}

	void CheckUnits()
	{
		// Check if a unit has died.
		// If a unit/units has died create the amount it needs to get to the max units.
	}

	void CreateUnits()
	{
		// Create enemies at pos.
		for (int i = 0; i < unitMaxAmount; i++)
		{
			Transform newUnit = Instantiate(unit, spawnPos.position, spawnPos.rotation);
			Vector3 newPos = new Vector3(target.position.x, target.position.y, target.position.z);
			newUnit.GetComponent<Units>().target = target;
			newUnit.SetParent(spawnPos);
			unitsList.Add(newUnit);
		}
	}

	public void RemoveUnit(Transform deadUnit)
	{
		unitsList.Remove(deadUnit);
		// Remove the unit out the list.
	}
}
