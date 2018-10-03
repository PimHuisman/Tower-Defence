using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    EnemyStrats enemyStats;

    AudioSource mySource;

    public bool hitTemple;

    // Use this for initialization
    void Start()
    {
        enemyStats = GetComponent<MyStats>().myStrats;
        GetComponent<NavMeshAgent>().speed = enemyStats.speed;
    }



    void OnCollisionEnter(Collision c)
    {
        //print("Colliding");

        if (c.gameObject.GetComponent<TempleStats>())
        {
            if (hitTemple == false)
            {
                print("Colliding with temple!");
                HurtTemple(c.gameObject.GetComponent<TempleStats>());
            }
        }
    }

    void HurtTemple(TempleStats temple)
    {
        hitTemple = true;
        temple.health -= enemyStats.health;
        temple.CheckHealth();


        Destroy(gameObject, 1);
    }
}
