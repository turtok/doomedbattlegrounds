using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkingManager : NetworkManager {

	private Transform spawnPlayer1;
	private Transform spawnPlayer2;

	// Use this for initialization
	void Start () {
		spawnPlayer1 = GameObject.Find ("/Scene/Spawn Position 1").transform;
		spawnPlayer2 = GameObject.Find ("/Scene/Spawn Position 2").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{
		if (spawnPlayer1.childCount == 0) {
			GameObject player = (GameObject)GameObject.Instantiate (playerPrefab, spawnPlayer1.position, Quaternion.identity);
			player.transform.SetParent (spawnPlayer1);
			player.transform.LookAt (GameObject.Find ("/Scene/Ground").transform.position);
			NetworkServer.Spawn (player);
		} else {
			GameObject player = (GameObject)GameObject.Instantiate (playerPrefab, spawnPlayer2.position, Quaternion.identity);
			player.transform.SetParent (spawnPlayer2);
			player.transform.LookAt (GameObject.Find ("/Scene/Ground").transform.position);
			NetworkServer.Spawn (player);
		}
		Debug.Log ("SPAWNED");
	}
}
