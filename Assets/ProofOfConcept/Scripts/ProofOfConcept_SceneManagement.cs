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
		if (thisScene.name != "ProofDeathScene") {
			sceneName = thisScene.name;
		}
		if (Input.GetKeyUp (KeyCode.U)) {
			SceneManager.LoadScene ("ProofStartScene");
		}

//		if (Input.GetKeyUp (KeyCode.Return) && sceneName == "ProofTitle") {
//			SceneManager.LoadScene ("ProofStartScene");
//		}

		if (SixLaneGameController.Instance.moveToNextLevel || ProofGameController.Instance.moveToNextLevel) {
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

		if (SixLaneGameController.Instance.gameOver || ProofGameController.Instance.gameOver) {
			SceneManager.LoadScene ("ProofDeathScene");
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
