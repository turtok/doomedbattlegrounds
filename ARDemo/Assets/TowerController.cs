using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerController : MonoBehaviour {

	public float lifepoints;
	public float lpAtStart;
	public bool isMain = false;

	private Image lpBar;

	// Use this for initialization
	void Start () {
		if (isMain) {
			lpAtStart = 150;
			lifepoints = lpAtStart;
		} else {
			lpAtStart = 100;
			lifepoints = lpAtStart;
		}
		Transform towerCanvas = null;
		for (int i = 0; i < this.transform.childCount; i++) {
			if (this.transform.GetChild(i).transform.name == "Canvas") {
				towerCanvas = this.transform.GetChild (i);
			}
		}
		if (towerCanvas != null) {
			for (int i = 0; i < towerCanvas.childCount; i++) {
				if (towerCanvas.GetChild (i).transform.name == "Healthbar") {
					lpBar = towerCanvas.GetChild(i).transform.GetComponent<Image> ();
					lpBar.fillAmount = 100;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (lifepoints <= 0) {
			Destroy (this.transform.parent.gameObject);
		}
	}

	public void Damage(float amount) {
		lifepoints -= amount;
		lpBar.fillAmount = lifepoints / lpAtStart;
	}
}
