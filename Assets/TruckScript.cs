using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckScript : MonoBehaviour {
    
	public float speed;
	int timesHit = 0;
	public AudioClip CrashMe;
	AudioSource mySource;

	// Use this for initialization
	void Start () {
		speed = 0f;
		mySource = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 temp = this.transform.position;
        temp.x -= speed;
        this.transform.position = temp;
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Little Boy") {
			speed = 0.3f;
			mySource.PlayOneShot (CrashMe, 1f);
		}
    }
}
