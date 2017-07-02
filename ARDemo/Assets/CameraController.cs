using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	public GameObject target;
	public float delay = 1;
	Vector3 offset;
	void Start () {
		offset = target.transform.position - new Vector3(0, 2, -1);
		Debug.Log (offset);
	}
	
	// Update is called once per frame
	void Update () {
		float currentAngle = transform.eulerAngles.y;
		float desiredAngle = target.transform.eulerAngles.y;
		float angle = Mathf.LerpAngle (currentAngle, desiredAngle, Time.deltaTime * delay);

		Quaternion rotation = Quaternion.Euler (0, angle, 0);
		transform.position = target.transform.position - (rotation * offset);

		transform.LookAt (target.transform);
	}
}
