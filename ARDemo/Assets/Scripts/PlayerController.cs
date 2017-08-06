using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerController : NetworkBehaviour {

	[SyncVar(hook = "OnReady")]public bool isReady = false;
	public GameObject battleUI_prefab;
	public float lpAtStart = 30;
	public float lifepoints = 30;

	private GameObject instructions_go;
	private Transform spawnPlayer1;
	private Transform spawnPlayer2;
	private SkinnedMeshRenderer clothesMeshRender = null;
	Transform playerCanvas = null;

	private Image lpBar;
	 
	// Use this for initialization
	void Start () {
		isReady = false;
		spawnPlayer1 = GameObject.Find ("/Scene/Spawn Position 1").transform;
		spawnPlayer2 = GameObject.Find ("/Scene/Spawn Position 2").transform;
		activateTutorialUI ();
		setupPlayerCanvas ();
		fillHealthBar ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (lifepoints <= 0) {
			// Destroy (this.transform.parent.gameObject);
		}
	}

	public override void OnStartLocalPlayer() {
//		Debug.Log ("ready StartClient: " + NetworkServer.connections [0].isReady);
//
//		if (isLocalPlayer) {
//			clothesMeshRender.material.SetColor ("_Color", Color.blue);
//		}
//		transform.LookAt (GameObject.Find ("/Scene/Ground").transform.position);
//
//		isReady = true;
	}


	public override void OnStartClient() {
	}	


	public void OnReady(bool ready) {
		if (ready) {
			Debug.Log ("Confirming Battlground...");
//			ARScene sceneController = GameObject.Find ("/Scene").GetComponent<ARScene> ();
//			if (sceneController != null) {
//				//deaktiviere 
//				sceneController.SetScenePosition();
//				//aktiviere Kampf-UI
//				GameObject uiCanvas = GameObject.Find("/Canvas");
//				GameObject instructionsUI_Canvas = GameObject.Find("Canvas/Instructions");
//				Debug.Log (uiCanvas.transform + " \n" + instructionsUI_Canvas + " \n" + battleUI_prefab + " \n");
//				if (instructionsUI_Canvas != null && uiCanvas != null && battleUI_prefab != null) {
//					Debug.Log ("found objects in scene");
//					GameObject battleUI = Instantiate (battleUI_prefab);
//					instructionsUI_Canvas.SetActive (false);
//					battleUI.transform.SetParent (uiCanvas.transform, false);
//					battleUI.name = "GameUI";
//					battleUI.SetActive (true);
//				}
//			}
		}
	}

	public void ConfirmBattleground() {
		Debug.Log ("confirmed");
		isReady = true;
	}

	private void activateTutorialUI() {
		// aktiviere ARSetup-UI
		instructions_go = GameObject.Find ("/Canvas/Instructions/");
		if (instructions_go != null) {
			foreach (Transform tutObject in instructions_go.transform.GetComponentInChildren<Transform>()) {
				if (tutObject.name.Equals ("SetPlace")) {
					tutObject.gameObject.SetActive (true);
				}
			}
		}
	}

	private void setupPlayerCanvas() {
		//Durchsuche ChildObjects nach Player-Canvas
		for (int i = 0; i < transform.childCount; i++) {
			Transform child = transform.GetChild (i);
			if (child.transform.name == "Canvas") {
				playerCanvas = transform.GetChild (i);
			}
			if (child.name.Equals ("BasicBandit_Clothes")) {
				clothesMeshRender = transform.GetChild (i).GetComponent<SkinnedMeshRenderer> ();
			}
		}
	}

	private void fillHealthBar() {
		//fülle healthbar-UI auf
		if (playerCanvas != null) {
			for (int i = 0; i < playerCanvas.childCount; i++) {
				if (playerCanvas.GetChild (i).transform.name == "Healthbar") {
					lpBar = playerCanvas.GetChild(i).transform.GetComponent<Image> ();
					lpBar.fillAmount = 100;
				}
			}
		}
	}
}
