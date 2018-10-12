using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public float minSize;
	public float maxSize;
	public float startSize;
	public float zoomSensetivity;
	public float horMoveSensetivity;
	public float verMoveSensetivity;
	public GameObject camObject;
	private Camera camCamera;

	void Start () {
		//Get Camera.
		camCamera = camObject.GetComponent<Camera> ();

		//Set size to start size
		SetSize (startSize);
	}

	void Update () {
		//Get scroll wheel input
		float scrollAxis = Input.GetAxis ("Mouse ScrollWheel");

		if (scrollAxis != 0) {
			//Set size of camera to new size
			SetSize (camCamera.orthographicSize + -scrollAxis * zoomSensetivity);
		}

		//Get WASD keys
		float verticalAxis = Input.GetAxisRaw ("Vertical");
		float horizontalAxis = Input.GetAxisRaw ("Horizontal");
		
		if (horizontalAxis != 0) {
			transform.Translate (-transform.right * horizontalAxis * horMoveSensetivity * Time.deltaTime);
		}
		if(verticalAxis != 0) {
			Quaternion oldRotation = transform.rotation;	
			
			transform.Translate(-new Vector3(transform.rotation.x, transform.rotation.y, 0.0f) * verticalAxis * verMoveSensetivity * Time.deltaTime);
			//transform.rotation = oldRotation;
			//transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
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