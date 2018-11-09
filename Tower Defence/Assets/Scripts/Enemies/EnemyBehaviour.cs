using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public EnemyStrats enemyStats;
    public bool hitTemple;
    public bool attack;
    [SerializeField] Vector3 target;
    [SerializeField] float raycastLength;
    bool isAttacking = false;
    [SerializeField] float damageTime;
    Transform targetObj;
    [SerializeField] Vector3 offset;
    Vector3 endPos;
    NavMeshAgent agent;
    RaycastHit hit;
    Animator anim;
    AudioSource mySource;
    bool damage = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine("AttackRate");
        StartCoroutine("Damage");
        GetComponent<NavMeshAgent>().speed = enemyStats.speed;
        agent = GetComponent<NavMeshAgent>();
        endPos = GameObject.FindGameObjectWithTag("EndPoint").transform.position;
        target = endPos;
        anim.SetFloat("IsWalking", 1);
    }

    void Update()
    {
        TargetDestanation(target);
        Attack();
    }

    void TargetDestanation(Vector3 newtarget)
    {
        agent.SetDestination(newtarget);
        if (targetObj == null)
        {
            agent.isStopped = false;
            anim.SetFloat("IsWalking", 1);
        }
    }

    IEnumerator AttackRate()
    {
        while (true)
        {
            while (attack)
            {
                if (targetObj != null)
                {
                    targetObj.gameObject.GetComponent<Units>().CalculateHealth(enemyStats.attackDamage);
                    damage = true;
                }
                yield return new WaitForSeconds(enemyStats.attackCooldown);
            }
            yield return null;
        }
    }

    IEnumerator Damage()
    {
        while (true)
        {
            while (damage)
            {
                anim.SetBool("IsAttacking", true);
                damage = false;
                anim.SetBool("IsAttacking", false);
                yield return new WaitForSeconds(damageTime);
            }

            yield return null;
        }
    }

    void Attack()
    {
        if (Physics.Raycast(transform.position + offset, transform.forward, out hit, raycastLength))
        {
            if (hit.transform.tag == "Unit")
            {
                if (!isAttacking)
                {
                    attack = true;
                    anim.SetBool("IsAttacking", true);
                }
            }
            else
            {
                anim.SetBool("IsAttacking", false);
                target = endPos;
                targetObj = null;
                attack = false;
            }
        }
        Debug.DrawRay(transform.position + offset, transform.forward * raycastLength, Color.red);
    }

    void HurtTemple(TempleStats temple)
    {
        hitTemple = true;
        temple.DamageMe(enemyStats.enterDamage);
        WaveSystem.instace.currentAmountOfEnemies--;
        Destroy(gameObject, 0.3f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            isAttacking = other.GetComponent<EnemyBehaviour>().attack;
            if (other.GetComponent<EnemyBehaviour>())
            {
                if (other.GetComponent<EnemyBehaviour>().attack)
                {
                    print(other.GetComponent<EnemyBehaviour>().attack);
                    target = endPos;
                }
            }
        }
        if (other.transform.CompareTag("Unit"))
        {
            agent.isStopped = true;
            anim.SetFloat("IsWalking", 0);
            targetObj = other.transform;
            if (other.transform.tag == "Enemy")
            {
                isAttacking = other.GetComponent<EnemyBehaviour>().attack;
                if (other.GetComponent<EnemyBehaviour>())
                {
                    if (other.GetComponent<EnemyBehaviour>().attack)
                    {
                        print(other.GetComponent<EnemyBehaviour>().attack);
                        target = endPos;
                    }
                }
            }

        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<TempleStats>())
        {
            if (hitTemple == false)
            {
                print("Colliding with temple!");
                HurtTemple(other.gameObject.GetComponent<TempleStats>());
            }
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject == null)
        {
            targetObj = null;
            target = endPos;
        }
    }
}