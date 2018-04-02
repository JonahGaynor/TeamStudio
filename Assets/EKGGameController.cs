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
            levelEnded = true;
            Debug.Log("Should End Level");
            ProofGameController.Instance.fadeToEnd = true;

        }
	}
}
