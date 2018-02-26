using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveMovement : MonoBehaviour {

	public float jumpSpeed;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) {
			rb.AddForce (0f, jumpSpeed);
		}
	}
}
