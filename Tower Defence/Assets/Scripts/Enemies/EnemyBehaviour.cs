using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    EnemyStrats enemyStats;

    AudioSource mySource;

    public bool hitTemple;
    public Transform unitPos;
    Vector3 target;
	NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {

        enemyStats = GetComponent<MyStats>().myStrats;
        GetComponent<NavMeshAgent>().speed = enemyStats.speed;
        agent = GetComponent<NavMeshAgent>();
		target = GameObject.FindGameObjectWithTag("EndPoint").transform.position;
    }

    void Update() 
    {
        TargetDestanation(target);
    }

    void TargetDestanation(Vector3 newtarget)
    {
        agent.SetDestination(newtarget);
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
            target = other.transform.position;
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

        if (other.gameObject.tag == "Unit")
        {
            other.gameObject.GetComponent<Units>().CalculateHealth(1);
        }
    }
}
