using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyFallingScript : MonoBehaviour {

	float rotationRandomizer;
	float positionRandomizer;
	public float fallSpeed = .000000001f;

	// Use this for initialization
	void Start () {
		rotationRandomizer = Random.Range (-20f, 20f);
		positionRandomizer = Random.Range (0f, 5f);
		transform.position = new Vector3 (transform.position.x, transform.position.y + 5f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (GameObject.Find ("Little Boy").transform.position.x + positionRandomizer, GameObject.Find ("Little Boy").transform.position.y + 5f - fallSpeed, 0f);
		fallSpeed += .000000001f;
//		transform.position.x = GameObject.Find ("Little Boy").transform.position.x + positionRandomizer;
//		transform.position.y -= fallSpeed;
		transform.rotation = Quaternion.Euler (0f, 0f, transform.rotation.z + rotationRandomizer);
	}
}
