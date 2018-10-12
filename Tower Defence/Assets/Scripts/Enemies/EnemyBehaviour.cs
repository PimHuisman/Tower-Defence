using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    EnemyStrats enemyStats;

    AudioSource mySource;

    public bool hitTemple;
    public bool attack;
    Transform targetObj;
    [SerializeField]Vector3 target;
    Vector3 endPos;
    NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("AttackRate");
        enemyStats = GetComponent<MyStats>().myStrats;
        GetComponent<NavMeshAgent>().speed = enemyStats.speed;
        agent = GetComponent<NavMeshAgent>();
        endPos = GameObject.FindGameObjectWithTag("EndPoint").transform.position;
        target = endPos;
    }

    void Update()
    {
        TargetDestanation(target);
    }

    void TargetDestanation(Vector3 newtarget)
    {
        agent.SetDestination(newtarget);

        if(attack)
        {
            if (targetObj == null)
            {
                newtarget = endPos;
            }
        }
    }

    IEnumerator AttackRate()
	{
		while (true)
        {
            while (attack)
            {
                yield return new WaitForSeconds(enemyStats.attackCooldown);
                if(targetObj != null)
                {
                    targetObj.gameObject.GetComponent<Units>().CalculateHealth(enemyStats.attackDamage);
                }
                
            }
            yield return null;
        }
	}

    void HurtTemple(TempleStats temple)
    {
        hitTemple = true;
        temple.health -= enemyStats.health;
        temple.CheckHealth();


        Destroy(gameObject, 1);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Unit")
        {
            Transform unitTarget = other.gameObject.GetComponent<Units>().attackTarget;
            if(unitTarget == null)
            {
                target = other.transform.position;  
            }
            else if(unitTarget != transform)
            {
                target = endPos;
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

    void OnCollisionStay(Collision other) 
    {
        if (other.gameObject.tag == "Unit")
        {
            attack = true;
            targetObj = other.gameObject.transform;
        }
    }

    void OnCollisionExit(Collision other) 
    {
        if (other.gameObject.tag == "Unit")
        {
            attack = false;
            targetObj = null;
        }
    }
}
