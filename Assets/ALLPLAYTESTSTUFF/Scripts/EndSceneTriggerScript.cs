using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneTriggerScript : MonoBehaviour {
	
	// check if trigger was hit
	// if it has, start fading out the camera
	// send message to the game controller to delete all furniture and stop spawning
	// once opacity is 255, send message to scene manager to switch scene

	public Material fadeToBlack;
	public SpriteRenderer getBlocker;
	float opacity = 0;
	bool readyToFade = false;
	public GameObject generator;

	// Use this for initialization
	void Start () {

		getBlocker = GameObject.Find ("Blocker").GetComponent<SpriteRenderer>();
		fadeToBlack = getBlocker.material;
        generator = GameObject.Find("Generator");

	}
	
	// Update is called once per frame
	void Update () {
		Color temp = fadeToBlack.color;
		temp.a = opacity;
		if (readyToFade) {
//			getBlocker.color.a = Mathf.Lerp(getBlocker.color.a, 255, .00001f);
			opacity = Mathf.Lerp(opacity, 255, .00001f);

		}
		fadeToBlack.color = temp;
		if (opacity >= 0.95f) {
            SixLaneGameController.Instance.moveToNextLevel = true;
            Debug.Log("Move To Next Level");

		}
		transform.position = new Vector3 (transform.position.x - .5f, transform.position.y, 0f);
	}

	void OnTriggerEnter2D (Collider2D otherCollider){
		if (otherCollider.tag == "Little Boy") {
			readyToFade = true;

			GameController.Instance.stopSpawning = true;

		}
	}
}
