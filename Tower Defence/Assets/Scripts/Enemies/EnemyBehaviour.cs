using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] EnemyStrats enemyStats;
    [SerializeField] int currentHealth;
    public bool hitTemple;

    // Use this for initialization
    void Start()
    {
        GetComponent<NavMeshAgent>().speed = enemyStats.speed;
        currentHealth = enemyStats.health;
    }

    public void Health(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision c)
    {
        print("Colliding");

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
