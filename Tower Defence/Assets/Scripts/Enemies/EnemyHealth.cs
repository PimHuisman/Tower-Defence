using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    EnemyStrats enemyStats;
    [SerializeField] GameObject audioPlayer;
    AudioSource mySource;
    [SerializeField] int currentHealth;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip damageSound;
    [SerializeField] GameObject damageParticles;
    [SerializeField] GameObject deathParticles;
    [SerializeField] HealthBar healthBarScript;
    Currency currencyScript;
    int unitHealth;
    void Start()
    {
        if (GetComponent<Units>() == null)
        {
            enemyStats = GetComponent<EnemyBehaviour>().enemyStats;
            currentHealth = enemyStats.health;
        }
        else
        {
            unitHealth = GetComponent<Units>().health;
            currentHealth = unitHealth;
        }
        currencyScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<Currency>();
    }

    public void DamageMe(int damage, Collision other)
    {
        currentHealth -= damage;

        MakeAndPlayAudio(damageSound, other);

        if (currentHealth <= 0)
        {
            Die(other);
            print("Dead");
        }
        else
        {
            healthBarScript.ChangeBar(currentHealth, enemyStats.health);
            PlayParticles(damageParticles, other.contacts[0].point, Quaternion.Euler(-other.contacts[0].normal));
        }
    }

    public void DamageMe2(int damage, Transform pos)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            print("dead");
        }
        healthBarScript.ChangeBar(currentHealth, enemyStats.health);
       // PlayParticles(damageParticles, pos.position, pos.rotation);
    }

    public void PlayParticles(GameObject parts, Vector3 position, Quaternion rotation)
    {
        GameObject newParts = Instantiate(damageParticles, position, rotation);
        ParticleSystem partSystem = newParts.GetComponent<ParticleSystem>();
        partSystem.Play();
        Destroy(newParts, partSystem.main.duration);
    }

    public void Die2()
    {
        Destroy(gameObject);
    }
    public void Die(Collision other)
    {
        if (other != null)
        {
            MakeAndPlayAudio(deathSound, other);
            PlayParticles(deathParticles, other.transform.position, other.transform.rotation);
            if (GetComponent<EnemyBehaviour>() != null)
            {
                currencyScript.AddCurrency(enemyStats.currencyWhenDead);
                currencyScript.AddCurrency(enemyStats.currencyWhenDead);
                WaveSystem.instace.currentAmountOfEnemies--;
            }
            Destroy(gameObject);
        }
        else
        {
            print("Works");
        }
    }


    public void MakeAndPlayAudio(AudioClip clip, Collision other)
    {
        if (other != null)
        {
            GameObject newPlayer = Instantiate(audioPlayer, other.contacts[0].point, audioPlayer.transform.rotation);
            mySource = newPlayer.GetComponent<AudioSource>();
            mySource.PlayOneShot(clip);
            Destroy(newPlayer, clip.length);
        }
    }
}
