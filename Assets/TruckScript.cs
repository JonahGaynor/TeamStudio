using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckScript : MonoBehaviour {
    float speed = 0.01f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 temp = this.transform.position;
        temp.x -= speed;
        this.transform.position = temp;
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Little Boy")
        {
            speed = 0;
        }
    }
}
