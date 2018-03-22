using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Little Boy");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 temp = this.transform.position;
        temp.x = player.transform.position.x - 30;
        this.transform.position = temp;
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "MoveScenes")
        {
            Destroy(collider.gameObject);
        }
    }
}
