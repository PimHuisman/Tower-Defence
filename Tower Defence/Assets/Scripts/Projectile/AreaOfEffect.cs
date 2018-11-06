using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AreaOfEffect : MonoBehaviour
{
    [SerializeField] float raduis;
    public int damage;

    public GameObject audioPlayer;
    public AudioClip hitAudio;
    public AudioMixerGroup mortarMixer;
    Collision col;
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Projectile")
        {
            //nothing
        }
        else
        {
            print(other.transform.name);
            col = other;
            DamageArea();
            print("do damage");
            MakeAndPlaySound(transform.position);
        }
    }

    void MakeAndPlaySound(Vector3 point)
    {
        GameObject newPlayer = Instantiate(audioPlayer, point, audioPlayer.transform.rotation);

        AudioSource mySource = newPlayer.GetComponent<AudioSource>();
        mySource.outputAudioMixerGroup = mortarMixer;

        mySource.PlayOneShot(hitAudio);

        Destroy(newPlayer, hitAudio.length);
    }

    void DamageArea()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, raduis);

        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.transform.tag == "Enemy")
            {
                if (!nearbyObject.transform.GetComponent<EnemyHealth>().DamageMe(damage, col))
                {
                    nearbyObject.transform.GetComponent<EnemyHealth>().DamageMe(damage, col);
                }
            }
        }

        Destroy(gameObject);
    }
}