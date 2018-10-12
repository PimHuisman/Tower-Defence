using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Units : MonoBehaviour
{
    NavMeshAgent agent;
    [HideInInspector] public Transform target;
    public Transform attackTarget;

    [Header("Health")]
    public int health;
    public int currentHealth;
    [Header("Raycast")]
    [SerializeField] Vector3 offset;
    [SerializeField] float attackRate;
    [SerializeField] int damage;
    bool isAttacking;
    RaycastHit hit;
    [SerializeField] float raycastLength;

    void Start()
    {
        attackTarget = null;
        StartCoroutine("AttackRate");
        agent = GetComponent<NavMeshAgent>();
        currentHealth = health;
    }

    void Update()
    {
        SetPosition();
        CheckHealth();
        Attack();
    }

    void SetPosition()
    {
        agent.SetDestination(target.position);
    }

    void CheckHealth()
    {
        if (currentHealth <= 0)
        {
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
    }

    public int CalculateHealth(int damage)
    {
        if(currentHealth <= 0)
        {
            return currentHealth = 0;
        }
        currentHealth -= damage;
        return currentHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyBehaviour>()) 
        {
            target = other.transform;
        }
    }

    void OnTriggerStay(Collider other) 
    {
        if (other.GetComponent<EnemyBehaviour>()) 
        {
            attackTarget = other.transform;
        }
        else
        {
            attackTarget = null;
        }
    }

    void Attack()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastLength))
        {
            if (hit.transform.tag == "Enemy")
            {
                isAttacking = true;
            }
            else
            {
                isAttacking = false;
            }
            Debug.DrawRay(transform.position + offset, transform.forward * raycastLength, Color.red);
        }
    }

    IEnumerator AttackRate()
    {
        while (true)
        {
            while (isAttacking)
            {
                yield return new WaitForSeconds(attackRate);
                hit.transform.gameObject.GetComponent<EnemyHealth>().DamageMe(damage, null);
            }
            yield return null;
        }
    }

}
