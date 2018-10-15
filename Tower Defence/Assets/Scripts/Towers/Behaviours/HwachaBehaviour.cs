using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HwachaBehaviour : TowerBehaviour {
    public float offset;
    public float maxTime;

    public void Start () {
        SetStats ();
        StartCoroutine (ShootRoutine ());
    }

    public void Update () {
        CheckEnemies ();
    }

    public override void Shoot () {
        int count = weapon.childCount;

        for (int i = 0; i < count; i++) {

            //currentProjectile = null;
            StartCoroutine("WaitForShoot", i);
        }
    }

    public IEnumerator WaitForShoot (int i) {
        float secs = Random.Range (0, maxTime);
        yield return new WaitForSeconds (secs);
        //print("Did " + i + " loops.");

        Transform currentChild = weapon.GetChild (i);
        //print("Shooting!");

        //currentChild.rotation = weapon.rotation;
        currentProjectile = Instantiate (projectile, currentChild.position, currentChild.rotation);
        currentProjectile.GetComponent<Stick> ().damage = damage;
        Calculate calc = currentProjectile.GetComponent<Calculate> ();
        calc.target = mainTarget;
        calc.launchAngle = angle;
        calc.Launch ();
        PlayAudio (shootClip);

        yield return null;
    }

    void OnTriggerEnter (Collider other) {
        base.Enter (other);
    }

    void OnTriggerExit (Collider other) {
        base.Exit (other);
    }

    public override void CheckEnemies () {
        base.CheckEnemies ();
    }
}