﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovementScript : MonoBehaviour {
    float speed = 0.01f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 temp = this.transform.position;
        temp.x -=speed*Time.timeScale;
        this.transform.position = temp;
	}
}
