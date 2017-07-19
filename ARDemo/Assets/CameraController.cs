using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	public GameObject target;
	public float distance = 2;
	Vector3 offset;
	void Start () {
		offset = new Vector3 (3, 2, 0);
		this.transform.position = target.transform.position + offset;
		this.transform.LookAt (target.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
