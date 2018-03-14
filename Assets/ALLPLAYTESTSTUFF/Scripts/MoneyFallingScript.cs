using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyFallingScript : MonoBehaviour {

	float rotationRandomizer;
	float positionRandomizer;
	float fallSpeed = .1f;
	float myRotation;
	float myPosition;

	// Use this for initialization
	void Start () {
		rotationRandomizer = Random.Range (-5f, 5f);
		positionRandomizer = Random.Range (-0.5f, 0.5f);
		transform.position = new Vector3 (GameObject.Find("Little Boy").transform.position.x, GameObject.Find("Little Boy").transform.position.y + 8f, 0f);
		myRotation = transform.rotation.z;
		myPosition =3;
	}
	
	// Update is called once per frame
	void Update () {
		
		fallSpeed += .1f;
//		transform.position.x = GameObject.Find ("Little Boy").transform.position.x + positionRandomizer;
//		transform.position.y -= fallSpeed;
		myRotation += rotationRandomizer;
		myPosition += positionRandomizer;
		transform.rotation = Quaternion.Euler (0f, 0f, myRotation);
        transform.position = new Vector3(GameObject.Find("Little Boy").transform.position.x + myPosition, GameObject.Find("Little Boy").transform.position.y + 8f - fallSpeed, 0f);

    }
}
