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
    Transform targetObj;
    Vector3 offset;
    Vector3 endPos;
    NavMeshAgent agent;
    RaycastHit hit;
    Animator anim;
    AudioSource mySource;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine("AttackRate");
        GetComponent<NavMeshAgent>().speed = enemyStats.speed;
        agent = GetComponent<NavMeshAgent>();
        endPos = GameObject.FindGameObjectWithTag("EndPoint").transform.position;
        target = endPos;
    }

    void Update()
    {
        TargetDestanation(target);
        Attack();
    }

    void TargetDestanation(Vector3 newtarget)
    {
        agent.SetDestination(newtarget);
        anim.SetFloat("IsWalking", agent.speed);
    }

    IEnumerator AttackRate()
    {
        while (true)
        {
            while (attack)
            {
                yield return new WaitForSeconds(enemyStats.attackCooldown);
                if (targetObj != null)
                {
                    anim.SetBool("IsAttacking", true);
                    targetObj.gameObject.GetComponent<Units>().CalculateHealth(enemyStats.attackDamage);
                    anim.SetBool("IsAttacking", false);
                }

            }
            yield return null;
        }
    }

    void Attack()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastLength))
        {
            if (hit.transform.tag == "Unit")
            {
                if (!isAttacking)
                {
                    attack = true;
                    target = hit.transform.position;
                }
            }
            else
            {
                attack = false;
            }
        }
        Debug.DrawRay(transform.position + offset, transform.forward * raycastLength, Color.red);
    }

    void HurtTemple(TempleStats temple)
    {
        hitTemple = true;
        temple.DamageMe(enemyStats.enterDamage);

        Destroy(gameObject, 0.5f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Unit")
        {
            if (attack)
            {
                agent.isStopped = true;
                anim.SetFloat("IsWalking", 0);
            }
        }

        if (other.transform.tag == "Enemy")
        {
            isAttacking = other.GetComponent<EnemyBehaviour>().attack;
            if (other.GetComponent<EnemyBehaviour>())
            {
                if (other.GetComponent<EnemyBehaviour>().attack)
                {
                    target = endPos;
                }
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //print("Colliding");

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
            target = endPos;
        }
    }
}
