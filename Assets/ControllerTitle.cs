using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTitle : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Return)) {
			ProofGameController.Instance.fadeToEnd = true;
		}

		if (GameObject.Find ("Blocker").GetComponent<SpriteRenderer> ().material.color.a >= 0.9f) {
			ProofGameController.Instance.moveToNextLevel = true;
		}
	}
}
