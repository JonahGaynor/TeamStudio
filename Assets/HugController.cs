using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugController : MonoBehaviour {
    public float timeTillOut = 1.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeTillOut -= Time.deltaTime;
        if (timeTillOut < 0){
            ProofGameController.Instance.fadeToEnd = true;
        }
	}
}
