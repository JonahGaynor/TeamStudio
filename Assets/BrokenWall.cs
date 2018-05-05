using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenWall : MonoBehaviour {

	public Rigidbody2D rb;
	float rotateMe = 0f;
	float myTime;

	// Use this for initialization
	void Start () {
		if (this.gameObject.name == "wall1") {
			rb.velocity = new Vector2 (2f, 3f);
		} else if (this.gameObject.name == "wall2") {
			rb.velocity = new Vector2 (3f, 2f);
		} else if (this.gameObject.name == "wall3") {
			rb.velocity = new Vector2 (3f, -2f);
		} else {
			rb.velocity = new Vector2 (2f, -3f);
		}
	}
//	
//	// Update is called once per frame
//	void Update () {
//		rotateMe += Time.deltaTime;
//		if (this.gameObject.name == "wall1") {
//			transform.Rotate (0f, 0f, 10);
//		} else if (this.gameObject.name == "wall2") {
//			transform.Rotate (0f, 0f, 5);
//		} else if (this.gameObject.name == "wall3") {
//			transform.Rotate (0f, 0f, -5);
//		} else {
//			transform.Rotate (0f, 0f, -10);
//		}
//	}

	void Update (){
		myTime += Time.deltaTime;
		if (myTime >= 0.5f) {
			Destroy (gameObject);
		}
		if (this.gameObject.name == "wall1") {
			transform.Rotate (0f, 0f, 5f);
		} else if (this.gameObject.name == "wall2") {
			transform.Rotate (0f, 0f, 2.5f);
		} else if (this.gameObject.name == "wall3") {
			transform.Rotate (0f, 0f, -2.5f);
		} else {
			transform.Rotate (0f, 0f, -5f);
		}
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Little Boy" && col.transform.gameObject.GetComponent<DashScript>().dashing) {
			rb.velocity = new Vector2 (15f, rb.velocity.y);
		}

	}

	IEnumerator waitASecNow(){
		yield return new WaitForSeconds (0.5f);
		this.GetComponent<BoxCollider2D> ().enabled = false;
	}
}
