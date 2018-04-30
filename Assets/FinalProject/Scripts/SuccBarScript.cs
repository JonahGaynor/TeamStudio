using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccBarScript : MonoBehaviour {

	public float myProgress;
	public float endSpot;
	public float startSpot;

	// Use this for initialization
	void Start () {
		startSpot = GameObject.Find ("StartSpot").GetComponent<Transform> ().position.y;
		endSpot = GameObject.Find ("EndSpot").GetComponent<Transform> ().position.y;
	}
	
	// Update is called once per frame
	void Update () {

        myProgress = (GameObject.Find ("ProofGameController").GetComponent<HomeLifeManager> ().stressLevel) / (GameObject.Find ("ProofGameController").GetComponent<HomeLifeManager> ().maxStress);
     
        this.transform.position = new Vector3 (transform.position.x,startSpot+((endSpot - startSpot) * myProgress), 0f);
	}
}
