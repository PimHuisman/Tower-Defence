using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculate : MonoBehaviour {
	public Transform target;
	float distanceToTarget;

	public float launchAngle;
	public Rigidbody myRb;
	public bool launched;
	bool hasLanded;

	// Use this for initialization
	void Start () {
		myRb.useGravity = false;
	}

	// Update is called once per frame
	void Update () {
		if (launched == true) {
			if (hasLanded == false) {

				transform.rotation = Quaternion.LookRotation (myRb.velocity);
			}
		}
	}

	public void Launch () {
		launched = true;
		myRb.useGravity = true;
		Vector3 projectileXZPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		Vector3 targetXZPos = new Vector3 (target.position.x, transform.position.y, target.position.z);

		transform.LookAt (targetXZPos);

		float R = Vector3.Distance (projectileXZPos, targetXZPos);
		float G = Physics.gravity.y;
		float tanAlpha = Mathf.Tan (launchAngle * Mathf.Deg2Rad);
		float H = target.position.y - transform.position.y;

		// calculate initial speed required to land the projectile on the target object 
		float Vz = Mathf.Sqrt (G * R * R / (2.0f * (H - R * tanAlpha)));
		float Vy = tanAlpha * Vz;

		// create the velocity vector in local space and get it in global space
		Vector3 localVelocity = new Vector3 (0f, Vy, Vz);

		Vector3 globalVelocity = transform.TransformDirection (localVelocity);

		// launch the object by setting its initial velocity and flipping its state
		myRb.velocity = globalVelocity;

	}

	void OnCollisionEnter (Collision c) {
		hasLanded = true;
	}
}