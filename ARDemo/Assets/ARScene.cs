using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

using UnityEngine.XR.iOS;

public class ARScene : MonoBehaviour {
	

	public int rotateSpeed = 20;
	public GameObject battleUI_prefab;
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
		player1 = GameObject.Find ("Player1").transform;
		player2 = GameObject.Find ("Player2").transform;
		isInstructions = true;
	}

	// Update is called once per frame
	void Update () {
		gameOver = CheckGameOver ();
		if (gameOver) {
			Debug.Log ("GAME OVER");
			Debug.Log ("Winner: " + GetWinner ().name);
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

	public void ConfirmBattleground() {
		Debug.Log ("Confirming Battlground...");
		SetScenePosition ();
		//aktiviere Kampf-UI
		GameObject uiCanvas = GameObject.Find("/Canvas");
		GameObject instructionsUI_Canvas = GameObject.Find("Canvas/Instructions");
		Debug.Log (uiCanvas.transform + " \n" + instructionsUI_Canvas + " \n" + battleUI_prefab + " \n");
		if (instructionsUI_Canvas != null && uiCanvas != null && battleUI_prefab != null) {
			Debug.Log ("found objects in scene");
			GameObject battleUI = Instantiate (battleUI_prefab);
			instructionsUI_Canvas.SetActive (false);
			battleUI.transform.SetParent (uiCanvas.transform, false);
			battleUI.name = "GameUI";
			battleUI.SetActive (true);
		}
		isInstructions = false;
	}

	void OnMouseDrag() {
		rotY = Input.GetAxis ("Mouse X") * rotateSpeed * Mathf.Deg2Rad;
		transform.RotateAround (Vector3.up, -rotY);
	}

	private void SetScenePosition() {
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
