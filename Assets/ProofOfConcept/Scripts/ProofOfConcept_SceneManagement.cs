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
		sceneName = thisScene.name;
		if (Input.GetKeyUp (KeyCode.U)) {
			SceneManager.LoadScene ("ProofStartScene");
		}

		if (Input.GetKeyUp (KeyCode.Return) && sceneName == "ProofTitle") {
			SceneManager.LoadScene ("ProofStartScene");
		}

		if (SixLaneGameController.Instance.moveToNextLevel) {
			if (sceneName == "ProofStartScene") {
				SceneManager.LoadScene ("ProofEKG");
				sceneName = thisScene.name;
			} else if (sceneName == "ProofEKG") {
				SceneManager.LoadScene ("ProofChildhood");
				sceneName = thisScene.name;
			} else {
				SceneManager.LoadScene ("ProofStartScene");
				sceneName = thisScene.name;
			}

		}
		if (Input.GetKeyUp (KeyCode.R)) {
			SceneManager.LoadScene (sceneName);
		}
	}
}
