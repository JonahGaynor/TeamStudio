using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlScript : MonoBehaviour {

	public float myOffset;

	// Use this for initialization
	void Start () {
		myOffset = 4f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (GameObject.Find ("Little Boy").GetComponent<Transform> ().position.x + myOffset, transform.position.y, 0f);
		if (SixLaneGameController.Instance.life == 3) {
			myOffset = 4f;
		} else if (SixLaneGameController.Instance.life == 2) {
			myOffset = 6f;
		} else if (SixLaneGameController.Instance.life == 1) {
			myOffset = 8f;
		} else {
			Debug.Log (SixLaneGameController.Instance.life);
		}
	}
}
