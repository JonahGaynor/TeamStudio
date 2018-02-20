using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControlScript : MonoBehaviour {

	//intended features:
	// 1. background moves! put on background tile prefab
	// 2. when background tile reaches a certain point, destroy it

	public float howFastToMove = 0.15f;
	public float destroyPoint = 0f;

	// Use this for initialization
	void Start () {
        howFastToMove = -0.05f;
    }
	
	// Update is called once per frame
	void Update () {
       
            Vector3 temp = this.transform.position;
            temp.x += howFastToMove;
            this.transform.position = temp;
    
		//transform.Translate (howFastToMove * Time.deltaTime, 0f, 0f);

	//	if (transform.position.x >= 875) {
		//	Destroy (this.gameObject);
		//}
	}
}
