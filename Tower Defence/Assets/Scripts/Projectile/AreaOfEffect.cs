using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffect : MonoBehaviour
{
    [SerializeField] float raduis;
    public int damage;
    Collision col;
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.gameObject)
        {
            print(other.transform.name);
            col = other;
            DamageArea();
            print("do damage");
        }
    }

    void DamageArea()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, raduis);

        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.transform.tag == "Enemy")
            {
                nearbyObject.transform.GetComponent<EnemyHealth>().DamageMe(damage, col);
            }
        }
        Destroy(gameObject);
    }
}
