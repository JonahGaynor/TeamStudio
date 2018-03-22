using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProofTriggerScript : MonoBehaviour {

	float sp;

	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag == "Little Boy") {
			sp = GetComponentInParent <TruckScript> ().speed;
			sp = 0.2f;
			GetComponentInParent<TruckScript> ().speed = sp;
		}

	}
}
