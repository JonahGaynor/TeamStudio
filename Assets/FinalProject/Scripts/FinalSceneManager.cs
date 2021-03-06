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
					PlayerPrefs.SetInt ("hasSeenInstructions", 0);
				} else if (scenesPast == 2) {
					SceneManager.LoadScene ("Cutscene_HighSchool");
				} else if (scenesPast == 3) {
					SceneManager.LoadScene ("Cutscene_Job");
				} else if (scenesPast == 4) {
					SceneManager.LoadScene ("Cutscene_ChildWaiting");
					PlayerPrefs.SetInt ("hasSeenInstructions", 0);
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
				PlayerPrefs.SetInt ("hasSeenInstructions", 0);
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
				PlayerPrefs.SetInt ("hasSeenInstructions", 0);
				sceneName = thisScene.name;
				hasSwitched = true;
				ProofGameController.Instance.moveToNextLevel = false;
			} else if (sceneName == "FinalHomeLife") {
				SceneManager.LoadScene ("Cutscene_Escape");
				sceneName = thisScene.name;
				hasSwitched = true;
				ProofGameController.Instance.moveToNextLevel = false;
			} else if (sceneName == "Cutscene_Escape") {
				SceneManager.LoadScene ("ProofEKG");
				sceneName = thisScene.name;
				hasSwitched = true;
				ProofGameController.Instance.moveToNextLevel = false;
			} else if (sceneName == "Cutscene_ChildWaiting") {
				SceneManager.LoadScene ("FinalReconnection");
                PlayerPrefs.SetInt("hasSeenInstructions", 0);
                scenesPast++;
				sceneName = thisScene.name;
				hasSwitched = true;
				ProofGameController.Instance.moveToNextLevel = false;
			} else if (sceneName == "FinalReconnection") {
				SceneManager.LoadScene ("HugScene");
				sceneName = thisScene.name;
				hasSwitched = true;
				ProofGameController.Instance.moveToNextLevel = false;
            }
            else if (sceneName == "HugScene")
            {
                SceneManager.LoadScene("FinalTruck");
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

		if (ProofGameController.Instance.gameOver) {
			if (sceneName == "ProofEKG") {
				SceneManager.LoadScene ("ProofDeathScene");
				sceneName = thisScene.name;
				ProofGameController.Instance.gameOver = false;
			} else if (sceneName == "ProofChildhood") {
				SceneManager.LoadScene ("ProofDeadChild");
				sceneName = thisScene.name;
				ProofGameController.Instance.gameOver = false;
			} else if (sceneName == "FinalCollege") {
				SceneManager.LoadScene ("DeadCollege");
				sceneName = thisScene.name;
				ProofGameController.Instance.gameOver = false;
			} else if (sceneName == "FinalHomeLife") {
				SceneManager.LoadScene ("DeadHomeLife");
				sceneName = thisScene.name;
				ProofGameController.Instance.gameOver = false;
			} else if (sceneName == "FinalReconnection") {
				SceneManager.LoadScene ("DeadReconnection");
				sceneName = thisScene.name;
				ProofGameController.Instance.gameOver = false;
			}

		}

		if (Input.GetKeyUp (KeyCode.R)) {
			if (sceneName == "ProofDeathScene") {
				SceneManager.LoadScene ("ProofEKG");
				sceneName = thisScene.name;

			} else if (sceneName == "ProofDeadChild") {
				SceneManager.LoadScene ("ProofChildhood");
				sceneName = thisScene.name;
			} else if (sceneName == "DeadCollege") {
				SceneManager.LoadScene ("FinalCollege");
				sceneName = thisScene.name;
			} else if (sceneName == "DeadHomeLife") {
				SceneManager.LoadScene ("FinalHomeLife");
				sceneName = thisScene.name;
			} else if (sceneName == "DeadReconnection") {
				SceneManager.LoadScene ("FinalReconnection");
				sceneName = thisScene.name;
			}

		}
		if (Input.GetKeyUp (KeyCode.Return) && sceneName == "Cutscene_HighSchool") {
			ProofGameController.Instance.moveToNextLevel = true;
		} else if (Input.GetKeyUp (KeyCode.Return) && sceneName == "Cutscene_Marriage") {
			ProofGameController.Instance.moveToNextLevel = true;
		} else if (Input.GetKeyUp (KeyCode.Return) && sceneName == "Cutscene_Job") {
			ProofGameController.Instance.moveToNextLevel = true;
		} else if (Input.GetKeyUp (KeyCode.Return) && sceneName == "Cutscene_Escape") {
			ProofGameController.Instance.moveToNextLevel = true;
		} else if (Input.GetKeyUp (KeyCode.Return) && sceneName == "Cutscene_ChildWaiting") {
			ProofGameController.Instance.moveToNextLevel = true;
		} else if (Input.GetKeyUp (KeyCode.Return) && sceneName == "FinalCredits") {
			SceneManager.LoadScene ("FinalReconnection");
			sceneName = thisScene.name;
		}

		if (Input.GetKeyUp (KeyCode.I) && sceneName == "ProofStartScene") {
			SceneManager.LoadScene ("FinalCredits");
			sceneName = thisScene.name;
			hasSwitched = true;
		}
	}
}
