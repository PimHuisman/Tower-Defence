using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalistaBehaviour : TowerBehaviour
{
    void Start()
    {
        SetStats();
    }

	void Update() {
		SetMainTarget();
	}


    void OnTriggerEnter(Collider other)
    {
        base.Enter(other);
    }

    void OnTriggerStay(Collider other)
    {
        base.Stay(other);
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
