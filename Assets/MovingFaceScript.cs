﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFaceScript : MonoBehaviour {
    public GameObject movingFace;
    public GameObject bar;
    public GameObject destination;
    public float distanceToTravel = 0.15f;
	// Use this for initialization
	void Start () {
        movingFace = this.transform.GetChild(1).gameObject;
        bar = this.transform.GetChild(0).gameObject;
        destination = this.transform.GetChild(2).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Little Boy").GetComponent<TestJump>()!=null && !GameObject.Find("Little Boy").GetComponent<TestJump>().ohMyGodYouDied)
        {
            movingFace.transform.position += new Vector3(distanceToTravel * Time.timeScale, 0, 0);
        }
        if (GameObject.Find("Little Boy").GetComponent<TestJump>() == null)
        {
            movingFace.transform.position += new Vector3(distanceToTravel * Time.timeScale, 0, 0);
        }
        

        if (ProofGameController.Instance.fadeToEnd){
            movingFace.SetActive(false);
            bar.SetActive(false);
            destination.SetActive(false);
        }
        if (movingFace.transform.position.x >750)
        {
            ProofGameController.Instance.fadeToEnd = true;
           // Debug.Log("You win!");
        }
	}
}
