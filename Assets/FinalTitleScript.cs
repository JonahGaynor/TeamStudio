using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalTitleScript : MonoBehaviour {

	bool haveStarted = false;
	bool fadeIn = false;
	Color temp;
	public Material myMaterial;

	void Start () {
		myMaterial = this.GetComponent<Image> ().material;
		temp = myMaterial.color;
		temp.a = 0;
		myMaterial.color = temp;
	}

	void Update () {
		if (ProofGameController.Instance.fadeToEnd && !haveStarted) {
			StartCoroutine (flashy ());
		}
		if (fadeIn && temp.a < 1f) {
			temp.a += 0.01f;
			myMaterial.color = temp;
			this.GetComponent<Image>().material = myMaterial;
		}
	}

	IEnumerator flashy(){
		haveStarted = true;
		yield return new WaitForSeconds (2.3f);
		this.GetComponent<Image> ().enabled = true;
		fadeIn = true;
	}
}
