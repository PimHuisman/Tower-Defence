using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempleStats : MonoBehaviour {
    public int beginHealth;
    float currentHealth;

    public Image healthImg;
    public float damage;
    public EndScreen endScreen;

    public bool doDamage;
    public bool hasBeenFound;

    void Start () {
        //endScreen = GameObject.FindGameObjectWithTag("Manager").GetComponent<EndScreen>(); 
        if (GameObject.FindGameObjectWithTag ("Manager") != null) {
            hasBeenFound = true;
        } else {
            hasBeenFound = false;
        }
        currentHealth = beginHealth;
        print ("Current health start " + currentHealth);

        ChangeUI();
    }

    void Update () {
        if (hasBeenFound == false) {    
            if (GameObject.FindGameObjectWithTag ("Manager") != null) {
                print("Found the object! DAB!");
                hasBeenFound = true;
            }
        }

    }

    public void DamageMe (float dmg) {
        currentHealth -= dmg;

        CheckHealth ();
        ChangeUI ();
    }

    public void CheckHealth () {
        if (currentHealth <= 0) {
            endScreen.Die ();
        }
    }

    public void ChangeUI () {
        float p = currentHealth / beginHealth;
        healthImg.fillAmount = p;

    }
}