﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneManager : MonoBehaviour {

	public Scene thisScene;
	public string sceneName;
	public int scenesPast = 0;

	// Use this for initialization
	void Start () {
		GameObject alreadyHere= GameObject.Find("SceneManager");
		if (alreadyHere != null&&alreadyHere!=this.gameObject)
		{

			Destroy(this.gameObject);
		}
		DontDestroyOnLoad (this.gameObject);
		thisScene = SceneManager.GetActiveScene();
		sceneName = thisScene.name;
	}
	
	// Update is called once per frame
	void Update () {
		thisScene = SceneManager.GetActiveScene();
        sceneName = thisScene.name;
        bool hasSwitched = false;
		if (ProofGameController.Instance.moveToNextLevel&&!hasSwitched) {

			if (sceneName == "ProofStartScene") {
				SceneManager.LoadScene ("ProofEKG");
				scenesPast++;
				sceneName = thisScene.name;
				hasSwitched = true;
				ProofGameController.Instance.moveToNextLevel = false;
			} else if (sceneName == "ProofEKG" && !hasSwitched) {
				if (scenesPast == 1) {
					SceneManager.LoadScene ("ProofChildhood");
				} else if (scenesPast == 2) {
					SceneManager.LoadScene ("Cutscene_HighSchool");
				} else if (scenesPast == 3) {
					SceneManager.LoadScene ("Cutscene_Job");
				} else if (scenesPast == 4) {
					SceneManager.LoadScene ("FinalReconnection");
				}
				sceneName = thisScene.name;
				hasSwitched = true;
				ProofGameController.Instance.moveToNextLevel = false;
			} else if (sceneName == "ProofChildhood" && !hasSwitched) {
				SceneManager.LoadScene ("ProofEKG");
				scenesPast++;
				sceneName = thisScene.name;
				hasSwitched = true;
				ProofGameController.Instance.moveToNextLevel = false;
			} else if (sceneName == "FinalCollege" && !hasSwitched) {
				SceneManager.LoadScene ("Cutscene_Marriage");
				sceneName = thisScene.name;
				hasSwitched = true;
				ProofGameController.Instance.moveToNextLevel = false;
			} else if (sceneName == "Cutscene_HighSchool") {
				SceneManager.LoadScene ("FinalCollege");
				sceneName = thisScene.name;
				hasSwitched = true;
				ProofGameController.Instance.moveToNextLevel = false;
			} else if (sceneName == "Cutscene_Marriage") {
				SceneManager.LoadScene ("ProofEKG");
				scenesPast++;
				sceneName = thisScene.name;
				hasSwitched = true;
				ProofGameController.Instance.moveToNextLevel = false;
			} else if (sceneName == "Cutscene_Job") {
				SceneManager.LoadScene ("FinalHomeLife");
				sceneName = thisScene.name;
				hasSwitched = true;
				ProofGameController.Instance.moveToNextLevel = false;
			} else if (sceneName == "FinalHomeLife") {
				SceneManager.LoadScene ("Cutscene_Escape");
				sceneName = thisScene.name;
				hasSwitched = true;
				ProofGameController.Instance.moveToNextLevel = false;
			} else if (sceneName == "Cutscene_Escape") {
				SceneManager.LoadScene ("Cutscene_ChildWaiting");
				sceneName = thisScene.name;
				hasSwitched = true;
				ProofGameController.Instance.moveToNextLevel = false;
			} else if (sceneName == "Cutscene_ChildWaiting") {
				SceneManager.LoadScene ("ProofEKG");
				scenesPast++;
				sceneName = thisScene.name;
				hasSwitched = true;
				ProofGameController.Instance.moveToNextLevel = false;
			} else if (sceneName == "FinalReconnection") {
				SceneManager.LoadScene ("FinalTruck");
				sceneName = thisScene.name;
				hasSwitched = true;
				ProofGameController.Instance.moveToNextLevel = false;
			} else if (sceneName == "FinalTruck")
            {
                hasSwitched = true;
                SceneManager.LoadScene("FinalCredits");
                ProofGameController.Instance.moveToNextLevel = false;

            }

		}
		if (Input.GetKeyUp (KeyCode.I) && sceneName == "ProofStartScene") {
			SceneManager.LoadScene ("FinalCredits");
			sceneName = thisScene.name;
			hasSwitched = true;
		}
	}
}
