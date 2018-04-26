using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeLifeManager : MonoBehaviour {

	public float stressLevel;
	public float stressMultiplier = 0.25f;
	public float maxStress = 30f;
	public int collectiblesGot = 0;
	public float myTimer = 0f;
	public static float firstCheckpoint = 20f;
	public static float secondCheckpoint = 40f;
	bool firstCheckpointHit = false;
	bool secondCheckpointHit = false;
	public Animator[] characterAnimators;
	public GameObject myPlayer;
	Animator myAnimator;

	// Use this for initialization
	void Start () {
		myPlayer = GameObject.Find ("Little Boy");
		myAnimator = myPlayer.GetComponent<Animator> ();
		myAnimator = characterAnimators [0];
	}
	
	// Update is called once per frame
	void Update () {
		stressLevel += Time.deltaTime * stressMultiplier;
		myTimer += Time.deltaTime;

		if (stressLevel >= maxStress && !secondCheckpointHit) {
			ProofGameController.Instance.gameOver = true;
		} else if (stressLevel >= maxStress && secondCheckpointHit) {
			ProofGameController.Instance.moveToNextLevel = true;
		}
		if (myTimer >= firstCheckpoint) {
			firstCheckpointHit = true;
			firstCheckpointSwitch ();
		}
		if (myTimer >= secondCheckpoint && firstCheckpointHit) {
			secondCheckpointHit = true;
			secondCheckpointSwitch ();
		}
	}

	void firstCheckpointSwitch () {
		myAnimator = characterAnimators [1];
	}

	void secondCheckpointSwitch () {
		myAnimator = characterAnimators [2];
	}

}
