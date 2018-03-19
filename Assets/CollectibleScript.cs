using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour {

	//TODO: make it play a boing sound effect

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.name == "Little Boy") {
			Destroy (this.gameObject);
		}
	}
}
