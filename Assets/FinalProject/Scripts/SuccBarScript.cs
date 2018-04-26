using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccBarScript : MonoBehaviour {

	public float myProgress;
	public float endSpot;
	public float startSpot;

	// Use this for initialization
	void Start () {
		startSpot = GameObject.Find ("StartSpot").GetComponent<Transform> ().position.x;
		endSpot = GameObject.Find ("EndSpot").GetComponent<Transform> ().position.x;
	}
	
	// Update is called once per frame
	void Update () {
		myProgress = (GameObject.Find ("ProofGameController").GetComponent<HomeLifeManager> ().stressLevel) / (GameObject.Find ("ProofGameController").GetComponent<HomeLifeManager> ().maxStress);
		this.transform.position = new Vector3 ((endSpot - startSpot) * myProgress), transform.position.y, 0f);
	}
}
