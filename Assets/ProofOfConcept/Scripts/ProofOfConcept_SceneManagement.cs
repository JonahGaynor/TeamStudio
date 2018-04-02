using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProofOfConcept_SceneManagement : MonoBehaviour {

	Scene thisScene;
	string sceneName;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		thisScene = SceneManager.GetActiveScene();
		sceneName = thisScene.name;
	}
	
	// Update is called once per frame
	void Update () {

		thisScene = SceneManager.GetActiveScene();
		if (thisScene.name != "ProofDeathScene" && thisScene.name != "ProofDeadChild") {
			sceneName = thisScene.name;
		}
		if (Input.GetKeyUp (KeyCode.U)) {
			SceneManager.LoadScene ("ProofStartScene");
		}

//		if (Input.GetKeyUp (KeyCode.Return) && sceneName == "ProofTitle") {
//			SceneManager.LoadScene ("ProofStartScene");
//		}

		if (ProofGameController.Instance.moveToNextLevel) {
			if (sceneName == "ProofStartScene") {
				SceneManager.LoadScene ("ProofEKG");
				sceneName = thisScene.name;
			} else if (sceneName == "ProofEKG") {
				SceneManager.LoadScene ("ProofChildhood");
				sceneName = thisScene.name;
			} else if (sceneName == "ProofTitle") {
				SceneManager.LoadScene ("ProofStartScene");
				sceneName = thisScene.name;
			} else {
				SceneManager.LoadScene ("ProofVictoryScene");
				sceneName = thisScene.name;
			}

		}

		if (ProofGameController.Instance.gameOver) {
			if (thisScene.name == "ProofEKG") {
				SceneManager.LoadScene ("ProofDeathScene");
				ProofGameController.Instance.gameOver = false;
			} else {
				SceneManager.LoadScene ("ProofDeadChild");
				ProofGameController.Instance.gameOver = false;
			}
//			sceneName = thisScene.name;
		}

		if (Input.GetKeyUp (KeyCode.R)) {
			SceneManager.LoadScene (sceneName);
			sceneName = thisScene.name;
		}

		if (Input.anyKey && sceneName == "ProofVictoryScene") {
			SceneManager.LoadScene ("ProofTitle");
			sceneName = thisScene.name;
		}
	}
}
