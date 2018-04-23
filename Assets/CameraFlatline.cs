using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlatline : MonoBehaviour {

	AudioSource myAudio;
	public AudioClip flatLine;

	// Use this for initialization
	void Start () {
		myAudio = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ProofGameController.Instance.fadeToEnd) {
			myAudio.PlayOneShot (flatLine, 0.05f);
		}
	}
}
