using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour {

	public SpriteRenderer sr;
	public AudioClip baDING;
	AudioSource myAudio;

	// Use this for initialization
	void Start () {
		sr = this.GetComponent<SpriteRenderer> ();
		myAudio = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.name == "Little Boy") {
			sr.enabled = false;
			myAudio.PlayOneShot (baDING, 1f);
		}
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Little Boy")
        {
			sr.enabled = false;
			myAudio.PlayOneShot (baDING, 1f);

        }
    }
}
