using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingCeilingTileScript : MonoBehaviour {

	public Vector2 playerVelocity;
	bool isOn = false;
	float myModifier = 0f;

	// Use this for initialization
	void Start () {
		playerVelocity = GameObject.Find ("Little Boy").GetComponent<Rigidbody2D> ().velocity;
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (Vector2.Distance (transform.position, GameObject.Find ("Little Boy").GetComponent<Transform>().position)) <= 1f) {
			myModifier += 0.2f;
			playerVelocity += Vector2.up * myModifier;
			isOn = true;
		} else if (isOn) {
			myModifier = 0f;
			isOn = false;
		}
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Little Boy") {
			ProofGameController.Instance.life--;

		}

	}
}
