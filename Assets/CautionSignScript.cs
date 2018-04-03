using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CautionSignScript : MonoBehaviour {
    SpriteRenderer myRenderer;
    int timer;
	// Use this for initialization
	void Start () {
        myRenderer = this.GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
        timer += 1;
        if (timer % 20 == 0&&myRenderer.enabled==true)
        {
            myRenderer.enabled = false;
        }
        else if (timer % 20 == 0 && myRenderer.enabled == false)
        {
            myRenderer.enabled = true;
        }
    }
}
