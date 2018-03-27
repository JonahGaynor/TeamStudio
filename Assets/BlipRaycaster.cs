using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlipRaycaster : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
        if (hit.collider!=null&&hit.collider.tag == "Floor")
        {
            BoxCollider2D floorCollider= hit.collider.GetComponent<BoxCollider2D>();
            floorCollider.enabled = false;
        }
    }
}
