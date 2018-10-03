using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HwachaBehaviour : TowerBehaviour
{
    public float offset;

    void Start()
    {
        SetStats();
        StartCoroutine(ShootRoutine());
    }

    void Update()
    {
        CheckEnemies();
    }

    public override void Shoot()
    {
        int count = weapon.childCount;

        for (int i = 0; i < count; i++)
        {
            print("Did " + i + " loops.");

            Transform currentChild = weapon.GetChild(i);
            //print("Shooting!");


            if (mainTarget != null)
            {
                weapon.LookAt(mainTarget.forward * offset + mainTarget.transform.position);
            }
            //currentChild.rotation = weapon.rotation;
            currentProjectile = Instantiate(projectile, currentChild.position, currentChild.rotation);
            currentProjectile.GetComponent<Stick>().damage = damage;
            Rigidbody projectileRb = currentProjectile.GetComponent<Rigidbody>();
            projectileRb.AddForce(currentProjectile.transform.forward * force);
            PlayAudio(shootClip);

            //currentProjectile = null;
        }
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
