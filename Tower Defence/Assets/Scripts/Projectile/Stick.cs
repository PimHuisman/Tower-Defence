using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public float timeToDestroy;
    public float pierceDepth;
    public int damage;

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag != "Tower")
        {
            if (other.gameObject.GetComponent<EnemyBehaviour>())
            {
                print("Arrow hit enemy!");

                if (other.transform.GetComponent<EnemyBehaviour>())
                {
                    other.transform.GetComponent<EnemyBehaviour>().DamageMe(damage);
                }
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
