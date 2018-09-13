using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleStats : MonoBehaviour
{
    public int health;
	public EndScreen endScreen;

    public bool doDamage;


    void Start() {
        endScreen = GameObject.FindGameObjectWithTag("Manager").GetComponent<EndScreen>();
    }

    void Update() {
        if(doDamage == true) {
            health -= 10;
            CheckHealth();
            
            doDamage = false;
        }
    }
    void CheckHealth()
    {
        if (health <= 0)
        {
            endScreen.Die();
        }
    }
}
