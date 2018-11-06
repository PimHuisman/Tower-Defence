using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempleStats : MonoBehaviour {
    public int beginHealth;
    float currentHealth;
    public float damage;
    public EndScreen endScreen;
    public Image currentHealthImg;

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
        float percentage;

        percentage = currentHealth / beginHealth;

        print ("Perc " + percentage);

        if (percentage <= 0) {
            currentHealthImg.fillAmount = 0;
        } else {
            currentHealthImg.fillAmount = percentage;
        }

    }
}