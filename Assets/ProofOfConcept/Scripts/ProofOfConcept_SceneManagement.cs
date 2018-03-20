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

		if (Input.GetKey (KeyCode.R)) {
			SceneManager.LoadScene ("ProofStartScene");
		}

		if (SixLaneGameController.Instance.moveToNextLevel) {
			if (sceneName == "ProofStartScene") {
				SceneManager.LoadScene ("ProofEKG");
			} else if (sceneName == "ProofEKG") {
				SceneManager.LoadScene ("ProofChildhood");
			} else {
				SceneManager.LoadScene ("ProofStartScene");
			}

		}
	}
}
