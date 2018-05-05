using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollegeCollectibleScript : MonoBehaviour {

	public float collectibleValue = 1f;

	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.name == "Little Boy" && this.gameObject.tag == "badCollectible") {
			GameObject.Find ("ProofGameController").GetComponent<HomeLifeManager> ().collectiblesGot += 1;
			GameObject.Find ("ProofGameController").GetComponent<HomeLifeManager> ().stressLevel += collectibleValue;

            StartCoroutine(GameObject.Find("Little Boy").GetComponent<HomeLifeJumpScript>().TakeDamage());

        } else if (col.gameObject.name == "Little Boy" && this.gameObject.tag == "Collectible") {
			GameObject.Find ("ProofGameController").GetComponent<HomeLifeManager> ().stressLevel -= collectibleValue;
			die ();
		}
	}

	void die () {
		Destroy (this.gameObject);
	}
}
