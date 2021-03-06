﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckScript : MonoBehaviour {
    
	public float speed;
	int timesHit = 0;
	public AudioClip CrashMe;
	AudioSource mySource;
    bool shouldSlowDown = false;
	Animator myAnimator;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("hasSeenInstructions", 0);
		speed = 0f;
		mySource = this.GetComponent<AudioSource> ();
		myAnimator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (shouldSlowDown)
        {
            speed = Mathf.Lerp(speed, 0, 0.025f);
        }
        Vector3 temp = this.transform.position;
        temp.x -= speed;
        this.transform.position = temp;
		if (Input.GetKey (KeyCode.Return)) {
			shouldSlowDown = false;
			speed = Mathf.Lerp (speed, 2f, 0.025f);
			myAnimator.enabled = true;
		}
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Little Boy") {

            shouldSlowDown = true;
			mySource.PlayOneShot (CrashMe, 1f);
			myAnimator.enabled = false;
		}
    }
}
