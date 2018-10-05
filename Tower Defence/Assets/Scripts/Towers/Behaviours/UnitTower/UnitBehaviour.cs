using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviour : MonoBehaviour
{
	[SerializeField] List<Transform> units = new List<Transform>();
	[SerializeField] Transform unit;
	[SerializeField] int unitMaxAmount;
	[SerializeField] Transform spawnPos;
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
			units.Add(newUnit);
		}
	}

	public void RemoveUnit()
	{
		// Remove the unit out the list.
	}
}
