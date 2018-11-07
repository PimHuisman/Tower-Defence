using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public float minSize;
	public float maxSize;
	public float startSize;
	public float zoomSensetivity;
	public float moveSensetivity;
	public GameObject camObject;
	private Camera camCamera;

	public GameObject ground;
	private Bounds groundBounds;
	private Vector3 extends;

	void Start () {
		//Get Camera.
		camCamera = camObject.GetComponent<Camera> ();

		//Set size to start size
		SetSize (startSize);

		GetBounds ();
	}

	void Update () {
		GetSizeChange ();
		GetPositionChange ();
	}

	void GetBounds () {
		Collider groundRend = ground.GetComponent<Collider> ();
		Bounds groundBounds = groundRend.bounds;
		print (groundBounds);

		extends = groundBounds.extents;

	}

	void GetPositionChange () {
		Vector3 oldPos = transform.position;

		//Get input
		float verticalInput = Input.GetAxisRaw ("Vertical");
		float horizontalInput = Input.GetAxisRaw ("Horizontal");

		transform.Translate (Vector3.forward * verticalInput * moveSensetivity);
		transform.Translate (Vector3.right * horizontalInput * moveSensetivity);
		Vector3 newPos = transform.position;

		//Only check if object is out of bounds if the pos has changed
		if (oldPos != newPos) {
			CheckExtends ();

		}
	}

	void CheckExtends () {
		//X Axis
		if (extends.x >= transform.position.x) {
			//print ("Transfrom is in positive extends.");
		} else {
			transform.position = new Vector3 (extends.x, transform.position.y, transform.position.z);
		}

		if (-extends.x <= transform.position.x) {
			//print ("Transform is in negative extends.");
		} else {
			transform.position = new Vector3 (-extends.x, transform.position.y, transform.position.z);
		}

		//Z Axis
		if (extends.z >= transform.position.z) {
			//print ("Transfrom is in positive extends.");
		} else {
			transform.position = new Vector3 (transform.position.x, transform.position.y, extends.z);
		}

		if (-extends.z <= transform.position.z) {
			//print ("Transform is in negative extends.");
		} else {
			transform.position = new Vector3 (transform.position.x, transform.position.y, -extends.z);
		}

	}

	void GetSizeChange () {
		//Get scroll wheel input
		float scrollAxis = Input.GetAxis ("Mouse ScrollWheel");

		if (scrollAxis != 0) {
			//Set size of camera to new size
			SetSize (camCamera.orthographicSize + -scrollAxis * zoomSensetivity);
		}
	}

	void SetSize (float size) {

		if (size > maxSize) {
			size = maxSize;
		} else if (size < minSize) {
			size = minSize;
		}
		camCamera.orthographicSize = size;
	}

}