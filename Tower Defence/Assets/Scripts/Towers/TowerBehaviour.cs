using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    List<Transform> targets = new List<Transform>();
    bool lockTarget;
    Transform mainTarget;
    public TowerStat tower;
    public Transform weapon;
    public Transform projectile;
    public Transform rangeObject;
    float range;
    float force;
    float damage;
    float fireRate;


    public virtual void SetStats()
    {
        range = tower.range;
        force = tower.force;
        damage = tower.damage;
        fireRate = tower.fireRate;
    }

    public virtual void Shoot()
    {
        projectile.LookAt(targets[0]);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        projectileRb.AddForce(projectile.forward * force);
    }

    public virtual void CheckEnemies()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] == null)
            {
                targets.Remove(targets[i]);
            }
        }
    }

    public virtual void Enter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            targets.Add(other.transform);
        }
    }

    public virtual void Stay(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Vector3 lead = new Vector3(targets[0].position.x, weapon.position.y, targets[0].position.z);
            weapon.transform.LookAt(lead);
        }
    }

    public virtual void Exit(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            targets.Remove(other.transform);
            CheckEnemies();
        }
    }

}
