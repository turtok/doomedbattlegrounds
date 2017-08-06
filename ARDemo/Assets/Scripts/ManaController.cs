using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaController : MonoBehaviour {

	public float speed = 0.05f;
	public int mana = 5;
	private Image manaImage;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < this.transform.childCount - 1; i++) {
			if (this.transform.GetChild(i).transform.name == "Mana") {
				manaImage = this.transform.GetChild(i).transform.GetComponent<Image> ();
				manaImage.fillAmount = 0;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (manaImage.fillAmount < 1) {
			manaImage.fillAmount += speed * Time.deltaTime;
			mana = getMana (manaImage.fillAmount);
		}
	}

	public void SubtractMana(int amount) {
		manaImage.fillAmount -= amount * 0.1f;
	}

	private int getMana(float fillAmount) {
		return (int) (fillAmount / 0.1);
	}
}
