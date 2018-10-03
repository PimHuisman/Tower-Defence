using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] EnemyStrats enemyStats;
    [SerializeField] int currentHealth;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip damageSound;
    [SerializeField] GameObject damageParticles;
    [SerializeField] GameObject deathParticles;
    AudioSource mySource;

    public bool hitTemple;

    // Use this for initialization
    void Start()
    {
        GetComponent<NavMeshAgent>().speed = enemyStats.speed;
        mySource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        currentHealth = enemyStats.health;
    }

    public void DamageMe(int damage, Collision other)
    {
        currentHealth -= damage;

        PlayAudio(damageSound);
        if (currentHealth <= 0)
        {
            PlayAudio(deathSound);
            PlayParticles(deathParticles, other.transform.position, other.transform.rotation);
            Die();
        }
        else
        {
            //PlayAudio(damageSound);
            PlayParticles(damageParticles, other.contacts[0].point, Quaternion.Euler(-other.contacts[0].normal));
        }
    }

    public void PlayAudio(AudioClip clip)
    {
        mySource.PlayOneShot(clip);
    }

    public void PlayParticles(GameObject parts, Vector3 position, Quaternion rotation)
    {
        GameObject newParts = Instantiate(damageParticles, position, rotation);
        ParticleSystem partSystem = newParts.GetComponent<ParticleSystem>();
        partSystem.Play();
        Destroy(newParts, partSystem.main.duration);
    }



    public void Die()
    {
        Destroy(gameObject);
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
