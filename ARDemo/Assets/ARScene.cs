using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Bigger() {
		transform.localScale += new Vector3 (0.01f, 0.01f, 0.01f);
	}

	public void Smaller() {
		if (transform.localScale.x > 0.01) {
			transform.localScale -= new Vector3 (0.01f, 0.01f, 0.01f);
		}
	}
}
