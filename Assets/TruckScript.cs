using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckScript : MonoBehaviour {
    
	public float speed;
	int timesHit = 0;

	// Use this for initialization
	void Start () {
		speed = 0f;
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
			speed = 0f;
		}
    }
}
