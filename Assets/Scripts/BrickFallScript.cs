using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickFallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameController.Instance.hitText)
        {
            Vector3 temp = this.transform.position;
            temp.y -= 0.01f;
            this.transform.position = temp;
        }
	}
}
