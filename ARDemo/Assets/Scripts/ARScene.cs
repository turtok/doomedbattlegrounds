using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Networking;
using System;

using UnityEngine.XR.iOS;

public class ARScene : NetworkBehaviour {
	

	public int rotateSpeed = 20;

	public bool gameOver = false;

	private float rotY = 0;
	private bool rotate = false;
	private GameObject sceneObject;
	private Transform player1;
	private Transform player2;

	private bool isInstructions;

	// Use this for initialization
	void Start () {
		sceneObject = this.gameObject;
		isInstructions = true;
	}

	// Update is called once per frame
	void Update () {
		if (isInstructions) {
			try {
				player1 = GameObject.Find ("Spawn Position 1/Player(Clone)/").transform;
				player2 = GameObject.Find ("Spawn Position 2/Player(Clone)/").transform;
				if (player1 != null && player2 != null) {
					Debug.Log("Player am start");
					isInstructions = false;
				}
			} catch (NullReferenceException e) {
				
			}
		}

		if (!isInstructions) {
			gameOver = CheckGameOver ();
			if (gameOver) {
				Debug.Log ("GAME OVER");
				Debug.Log ("Winner: " + GetWinner ().name);
			}
		}
	}
		
	bool HitTestWithResultType (ARPoint point, ARHitTestResultType resultTypes)
	{
		List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface ().HitTest (point, resultTypes);
		if (hitResults.Count > 0) {
			foreach (var hitResult in hitResults) {
				return true;
			}
		}
		return false;
	}

	void OnMouseDrag() {
		rotY = Input.GetAxis ("Mouse X") * rotateSpeed * Mathf.Deg2Rad;
		transform.RotateAround (Vector3.up, -rotY);
	}

	public void SetScenePosition() {
		if (this.GetComponent<UnityARHitTestExample> () != null) {
			this.GetComponent<UnityARHitTestExample> ().enabled = false;
		}
	}

	private bool CheckGameOver() {
		bool result = false;
		if (player1.childCount == 0 || player2.childCount == 0) {
			result = true;
		}
		return result;
	}

	private Transform GetWinner() {
		if (player1.childCount != 0) {
			return player1;
		}
		return player2;
	}

	private Transform GetLooser() {
		if (player1.childCount == 0) {
			return player1;
		}
		return player2;
	}
}
