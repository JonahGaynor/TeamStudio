using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingCavnasScript : MonoBehaviour {

	bool haveStarted = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (ProofGameController.Instance.fadeToEnd && !haveStarted) {
			StartCoroutine (flashy ());
		}
	}

	IEnumerator flashy(){
		haveStarted = true;
		yield return new WaitForSeconds (2.3f);
		this.transform.GetChild (0).GetComponent<Image> ().enabled = true;
		yield return new WaitForSeconds (0.15f);
		this.transform.GetChild (1).GetComponent<Image> ().enabled = true;
		yield return new WaitForSeconds (0.15f);
		this.transform.GetChild (2).GetComponent<Image> ().enabled = true;
		yield return new WaitForSeconds (0.15f);
		this.transform.GetChild (3).GetComponent<Image> ().enabled = true;
		yield return new WaitForSeconds (0.15f);
		this.transform.GetChild (0).GetComponent<Image> ().enabled = false;
		this.transform.GetChild (1).GetComponent<Image> ().enabled = false;
		this.transform.GetChild (2).GetComponent<Image> ().enabled = false;
		this.transform.GetChild (3).GetComponent<Image> ().enabled = false;
	}
}
