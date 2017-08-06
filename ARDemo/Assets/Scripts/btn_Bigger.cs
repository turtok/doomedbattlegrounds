using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btn_Bigger : MonoBehaviour {

	private Button bigger;
	// Use this for initialization
	void Start () {
		bigger = this.GetComponent<Button> ();
		bigger.onClick.AddListener (Bigger);
	}

	private void Bigger() {
		Transform sceneTransform = GameObject.Find ("Scene").transform;
		if (sceneTransform != null) {
			sceneTransform.transform.localScale += new Vector3 (0.01f, 0.01f, 0.01f);	
		}
	}
}
