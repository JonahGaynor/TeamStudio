using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveMovement : MonoBehaviour {

	float jumpForce;
	public Rigidbody2D rb;
	float runSpeed = 0.2f;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
		jumpForce = 2f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			rb.AddForce (transform.up * jumpForce);
			Debug.Log (jumpForce);
			Debug.Log ("Let's jump!");
		}
		runSpeed = SixLaneGameController.Instance.standardMoveSpeed;
		Vector3 temp = this.transform.position;
		temp.x += runSpeed;
		this.transform.position = temp;
	}
}
