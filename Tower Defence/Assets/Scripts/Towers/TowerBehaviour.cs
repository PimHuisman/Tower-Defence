using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public List<Transform> targets = new List<Transform>();
    public bool lockTarget;
    public Transform weapon;
    public Transform mainTarget;

    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Shoot()
    {

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
