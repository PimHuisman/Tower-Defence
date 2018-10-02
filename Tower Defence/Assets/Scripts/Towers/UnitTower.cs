using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTower : TowerBehaviour
{
    [SerializeField] GameObject unit;
    [SerializeField] int unitMaxAmount;
    [SerializeField] Transform areaPos;
    public List<Transform> unitList = new List<Transform>();
    public override void Start()
    {
        GenerateArrows();
    }

    public override void Update()
    {

    }

    public override void Shoot()
    {

    }
    public void GenerateArrows()
    {
        for (int i = 0; i < unitMaxAmount; i++)
        {
            Instantiate(unit, areaPos.position, areaPos.rotation);
        }
    }
}
