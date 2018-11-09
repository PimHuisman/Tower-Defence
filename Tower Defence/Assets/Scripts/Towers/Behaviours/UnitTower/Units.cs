using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

public class Units : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    [HideInInspector] public Transform target;
    Transform tragetOpsl;
    [SerializeField] float minDist;
    [SerializeField] float maxDist;

    [Header("Health")]
    public int health;
    public int currentHealth;

    [Header("Raycast")]
    [SerializeField] Vector3 offset;
    [SerializeField] float attackRate;
    [SerializeField] float damageTime;
    [SerializeField] int damage;
    [SerializeField] bool isAttacking;
    RaycastHit hit;
    [SerializeField] float raycastLength;
    public EnemyStrats unitStats;
    [SerializeField] HealthBar healthBarScript;
    Vector3 newPos;
    [HideInInspector] public Transform targetObject;
    bool damagebool = false;

    void Start()
    {
        StartCoroutine("Damage");
        tragetOpsl = target;
        GetComponent<NavMeshAgent>().speed = unitStats.speed;
        anim = GetComponent<Animator>();
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
        float dist = Vector3.Distance(transform.position, target.position);
        if (dist >= maxDist)
        {
            agent.SetDestination(tragetOpsl.position);
        }
        if (dist <= minDist)
        {
            print("Up Close");
            anim.SetFloat("IsWalking", 0);
            agent.isStopped = true;
        }
        else
        {
            if (isAttacking)
            {
                agent.isStopped = false;
                anim.SetFloat("IsWalking", 1);
            }
        }
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
        if (currentHealth <= 0)
        {
            return currentHealth = 0;
        }
        healthBarScript.ChangeBar(currentHealth, health);
        currentHealth -= damage;
        return currentHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyBehaviour>())
        {
            if (isAttacking)
            {

            }
            else
            {
                targetObject = other.transform;
                isAttacking = true;
                newPos = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z);
                target.position = newPos;
                anim.SetFloat("IsWalking", 1);
            }
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
                anim.SetBool("IsAttacking", false);
            }
        }
        Debug.DrawRay(transform.position + offset, transform.forward * raycastLength, Color.red);
    }

    IEnumerator AttackRate()
    {
        while (true)
        {
            while (isAttacking)
            {
                if (targetObject != null)
                {
                    damagebool = true;
                    targetObject.gameObject.GetComponent<EnemyHealth>().DamageMe2(damage, hit.transform);
                }
                yield return new WaitForSeconds(attackRate);
            }
            yield return null;
        }
    }

    IEnumerator Damage()
    {
        while (true)
        {
            while (damagebool)
            {
                anim.SetBool("IsAttacking", true);
                damagebool = false;
                anim.SetBool("IsAttacking", false);
                yield return new WaitForSeconds(damageTime);
            }
            yield return null;
        }

    }
}
