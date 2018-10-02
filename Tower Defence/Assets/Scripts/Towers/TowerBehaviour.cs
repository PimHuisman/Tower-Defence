using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public List<Transform> targets = new List<Transform>();
    Transform mainTarget;
    public TowerStat tower;
    public Transform weapon;
    public GameObject projectile;
    GameObject currentProjectile;
    public Transform projectileSpawn;
    float respawnPercentage;
    public AudioSource mySource;
    public AudioClip shootClip;

    float range;
    float force;
    int damage;
    float fireRate;


    public virtual void SetStats()
    {
        range = tower.range;
        force = tower.force;
        damage = tower.damage;
        fireRate = tower.fireRate;
        respawnPercentage = tower.projectileRespawnPercentage;
        SetRange();
    }

    public virtual void SetRange()
    {
        SphereCollider c = GetComponent<SphereCollider>();
        c.radius = range;
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
        SetMainTarget();
    }
    public virtual void SetMainTarget()
    {
        if (targets.Count != 0)
        {
            if (targets[0] != null)
            {
                mainTarget = targets[0];
                WeaponTarget();
            }
        }
    }


    public virtual void WeaponTarget()
    {
        weapon.LookAt(new Vector3(mainTarget.position.x, weapon.position.y, mainTarget.position.z));
    }

    public virtual void Shoot()
    {
        print("Shooting!");
        currentProjectile = Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
        currentProjectile.GetComponent<Stick>().damage = damage;
        currentProjectile.transform.LookAt(mainTarget);
        Rigidbody projectileRb = currentProjectile.GetComponent<Rigidbody>();
        projectileRb.AddForce(currentProjectile.transform.forward * force);
        PlayAudio(shootClip);
        
        currentProjectile = null;
    }


    public virtual void Enter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            print("Enemy is entering.");
            targets.Add(other.transform);
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
    public virtual IEnumerator ShootRoutine()
    {
        while (true)
        {
            while (targets.Count > 0)
            {
                yield return new WaitForSeconds(1f / fireRate);
                Shoot();
            }
            yield return null;
        }
    }

    public virtual void PlayAudio(AudioClip myClip) {
        mySource.clip = myClip;
        mySource.Play();
    }
}
