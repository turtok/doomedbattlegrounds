using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUI : MonoBehaviour {

	private Transform cameraTransform;
	// Use this for initialization
	void Awake () {
		cameraTransform = GameObject.Find ("CameraParent/Main Camera").transform;
	}

	// Update is called once per frame
	void Update () {
		if (cameraTransform != null) {
			this.transform.LookAt (
				this.transform.position + cameraTransform.rotation * Vector3.back, 
				cameraTransform.rotation * Vector3.down);
		}
	}
}
