using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HwachaBehaviour : TowerBehaviour
{
    public override void CheckEnemies()
    {
        base.CheckEnemies();
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
}
