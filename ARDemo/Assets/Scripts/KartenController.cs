using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class KartenController : MonoBehaviour {

	public GameObject zombie;
	public int manaCost = 2;
	public bool playable = false;

	private Vector3 spawnPoint;
	private Transform mainTowerTransform;
	private Transform enemyMainTowerTransform;
	private Transform scene;
	private ManaController manaController;

	void Start() {
		mainTowerTransform = GameObject.Find ("/Scene/Spawn Position 1/Player(Clone)/MainTower").transform;

		spawnPoint = new Vector3 (mainTowerTransform.position.x - 0.275f, 0, 0); 
		scene = GameObject.Find ("Scene").transform;
		//manaController = 
	}

	void Update() {
		if (manaController == null) {
			manaController = GameObject.Find ("Canvas/GameUI/ManaBar").GetComponent<ManaController> ();
		} else {
			playable = manaController.mana >= manaCost;	
		}
	}

	public void activate() {
		//TODO: Find shortest way to next enemy
		enemyMainTowerTransform = GameObject.Find ("/Scene/Spawn Position 2/Player(Clone)/MainTower").transform;

		//Karteneffekt
		if (manaController.mana >= manaCost) {
			//berechne Mana
			manaController.SubtractMana(manaCost);

			//aktiviere Effekt
			GameObject spawn = Instantiate(zombie, scene);
			spawn.transform.localPosition = spawnPoint;
			spawn.transform.LookAt (enemyMainTowerTransform.position);
			ZombieControl zb = spawn.GetComponent<ZombieControl> ();
			zb.walk ();

		}

	}
}
