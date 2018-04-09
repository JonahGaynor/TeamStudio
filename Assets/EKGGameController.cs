using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EKGGameController : MonoBehaviour {
    public float timeSinceLevelBegan=0;
    public float timeForLevel =15;
    public bool levelEnded = false;
    public GameObject camera;
	// Use this for initialization
	void Start () {
        camera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLevelBegan += Time.deltaTime;
        if (timeSinceLevelBegan > timeForLevel&&!levelEnded)
        {
           // camera.GetComponent<CameraControl>().SendMessage("GetFaded");
			ProofGameController.Instance.fadeToEnd = true;
			GameObject.Find ("Little Boy").GetComponent<TestJump> ().canGetHit = false;
            levelEnded = true;
            GameObject[] shitToDelete = GameObject.FindGameObjectsWithTag("Furniture");
            foreach(GameObject blip in shitToDelete)
            {
                Destroy(blip.gameObject);
            }

        }
		if (GameObject.Find ("Blocker").GetComponent<SpriteRenderer> ().material.color.a >= 0.9f && levelEnded && timeSinceLevelBegan > timeForLevel) {
			ProofGameController.Instance.moveToNextLevel = true;
		}
	}
}
