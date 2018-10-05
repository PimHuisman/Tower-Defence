using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Units : MonoBehaviour
{
    NavMeshAgent agent;
    [HideInInspector] public Transform target;
    public int health;
    public int currentHealth;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentHealth = health;
    }

    void Update()
    {
        SetPosition();
    }

    void SetPosition()
    {
        agent.SetDestination(target.position);
    }

    public void CalculateHealth(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            if (gameObject.GetComponentInParent<UnitBehaviour>())
            {
                gameObject.GetComponentInParent<UnitBehaviour>().RemoveUnit(transform);
                Destroy(gameObject);
            }
            else
            {
                print("Parent doesn't have UnitBehaviour script!");
            }
        }
        // Check if your health is zero.
        // If it is zero say to your tower remove me.
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<EnemyBehaviour>()) {
            target = other.transform;
        }
    }

    IEnumerator AttackRate()
    {

        yield return new WaitForSeconds(0);
    }

}
