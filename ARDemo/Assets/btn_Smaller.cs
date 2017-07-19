using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btn_Smaller : MonoBehaviour {

	private Button smaller;
	// Use this for initialization
	void Start () {
		smaller = this.GetComponent<Button> ();
		smaller.onClick.AddListener (Smaller);
	}

	private void Smaller() {
		Transform sceneTransform = GameObject.Find ("Scene").transform;
		if (sceneTransform != null) {
			if (sceneTransform.transform.localScale.x > 0.01) {
				sceneTransform.transform.localScale -= new Vector3 (0.01f, 0.01f, 0.01f);
			}	
		}
	}
}
