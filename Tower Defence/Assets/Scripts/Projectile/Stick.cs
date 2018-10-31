using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public float timeToDestroy;
    public float pierceDepth;
    public int damage;
    public GameObject audioPlayer;

    private AudioSource mySource;
    public AudioClip stickAudio;

    void MakeAndPlaySound(Vector3 point)
    {
        GameObject newPlayer = Instantiate(audioPlayer, point, audioPlayer.transform.rotation);

        mySource = newPlayer.GetComponent<AudioSource>();

        mySource.PlayOneShot(stickAudio);

        Destroy(newPlayer, stickAudio.length);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag != "Tower" || other.transform.tag == "Projectile")
        {
            if (other.transform.GetComponent<Stick>())
            {

            }
            else
            {
                MakeAndPlaySound(other.contacts[0].point);

                if (other.gameObject.GetComponent<EnemyBehaviour>())
                {
                    //print("Arrow hit enemy!");
                    other.transform.GetComponent<EnemyHealth>().DamageMe(damage, other);
                }

                GameObject emptyGameObject = new GameObject();
                emptyGameObject.transform.parent = other.transform;
                transform.parent = emptyGameObject.transform;
                Destroy(transform.GetComponent<Rigidbody>());
                Destroy(emptyGameObject, timeToDestroy);
                Destroy(transform.GetComponent<Collider>());



                transform.Translate(transform.forward * pierceDepth);
            }

        }
    }
}
