using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// umbenennen in EinheitController
public class ZombieControl : MonoBehaviour {

	public float moveSpeed = 0.5f;
	public float dps = 10;
	private Animation animation;
	private bool moving;
	private bool attacking;
	private GameObject targetEnemyTower;
	private float lastHitTime;

	// Use this for initialization
	void Awake () {
		animation = this.GetComponent<Animation> ();
	}

	void Start() {
		lastHitTime = Time.time;
	}
		

	// Update is called once per frame
	void Update () {
		if (moving) {
			//orientieren

			//bewege Zombie
			transform.Translate(Vector3.forward * Time.deltaTime * (transform.localScale.x * moveSpeed));
		}
		if (attacking) {
			//mach schaden im collision object
			if (targetEnemyTower != null) {
				if (Time.time - lastHitTime >= 1) {
					targetEnemyTower.GetComponent<TowerController> ().Damage (dps);
					lastHitTime = Time.time;
				}	
			} else {
				// object ist zerstört suche neues generisches ziel und laufe drauf zu
				//stoppe attack anim
				attack();
				//orientiere neuen gegner
				LookOutForNextEnemy();
				//laufe
				walk();
			}
		}
	}

	void OnTriggerEnter (Collider col)
	{

		if(col.gameObject.name == "Tower")
		{
			walk ();
			//mach schadenphase in update mit attacking
			attack();
			targetEnemyTower = col.gameObject;
		}
	}

	private void LookOutForNextEnemy() {
		// player2 childs holen, 
		Transform player2 = GameObject.Find ("Player2").transform;
		List<Transform> enemyTowers = new List<Transform> ();
		for (int i = 0; i < player2.childCount; i++) {
			enemyTowers.Add(player2.GetChild (i));
		}
		// bei mehreren den kürzesten nehmen
		Transform shortest = null;
		if (enemyTowers != null) {
			shortest = enemyTowers [0];
			foreach (Transform tower in enemyTowers) {
				if(Vector3.Distance(transform.localPosition, tower.position) <= Vector3.Distance(transform.localPosition, shortest.position))
				{
					shortest = tower;
				}
			}
		}
		//lookat aufrufen*/
		if (shortest != null) {
			Debug.Log (shortest.name);
			transform.LookAt (shortest);
			transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
		}

	}

	private void attack() {
		//füge player2 dmg zu, alle x sec, spiele animation ab.
		if (!animation.isPlaying) {
			animation.Play("attack");
			attacking = true;
		} else {
			animation.Stop("attack");
			attacking = false;
		}
	}

	public void walk() {
		if (!animation.isPlaying) {
			animation.Play("walk");
			moving = true;
		} else {
			animation.Stop("walk");
			moving = false;
		}
	}

	public void LookAt() {
		transform.LookAt (Camera.main.transform.position);
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
	}

	public void Bigger () {
		transform.localScale += new Vector3 (1, 1, 1);
	}

	public void Smaller () {
		if (transform.localScale.x > 1) {
			transform.localScale -= new Vector3 (1, 1, 1);
		}
	}

	public void ResetLocalPosition() {
		transform.localPosition = Vector3.zero;
	}
}
