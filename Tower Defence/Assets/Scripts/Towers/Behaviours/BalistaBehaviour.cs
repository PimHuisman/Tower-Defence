using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalistaBehaviour : TowerBehaviour
{
    public override void Start()
    {
        SetStats();
		StartCoroutine(ShootRoutine());
    }

    public override void Update()
    {
        CheckEnemies();
    }

    void OnTriggerEnter(Collider other)
    {
        base.Enter(other);
    }

    void OnTriggerExit(Collider other)
    {
        base.Exit(other);
    }

    public override void CheckEnemies()
    {
        base.CheckEnemies();
    }
}
