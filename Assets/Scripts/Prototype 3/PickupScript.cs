﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag=="Little Boy")
        {
            ScaryGameController.Instance.numPickups++;
            Destroy(this.gameObject);
        }


    }
}