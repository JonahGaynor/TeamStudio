using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlipSound : MonoBehaviour {
    AudioSource blip;
	// Use this for initialization
	void Start () {
        blip = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        blip.Play();
    }
}
