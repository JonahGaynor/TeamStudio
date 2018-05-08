using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProofOfConcept_SceneManagement : MonoBehaviour {

	Scene thisScene;
	string sceneName;

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
		if (thisScene.name != "ProofDeathScene" && thisScene.name != "ProofDeadChild") {
			sceneName = thisScene.name;
		}
		if (Input.GetKeyUp (KeyCode.U)) {
			SceneManager.LoadScene ("ProofTitle");
		}

        //		if (Input.GetKeyUp (KeyCode.Return) && sceneName == "ProofTitle") {
        //			SceneManager.LoadScene ("ProofStartScene");
        //		}
        bool hasSwitched = false;
		if (ProofGameController.Instance.moveToNextLevel&&!hasSwitched) {

			if (sceneName == "ProofStartScene") {
                ProofGameController.Instance.moveToNextLevel = false;
                SceneManager.LoadScene ("ProofEKG");
				sceneName = thisScene.name;
                hasSwitched = true;
                ProofGameController.Instance.moveToNextLevel = false;
			} else if (sceneName == "ProofEKG"&&!hasSwitched) {
				SceneManager.LoadScene ("ProofChildhood");
				sceneName = thisScene.name;
                hasSwitched = true;
                ProofGameController.Instance.moveToNextLevel = false;
            }
            else if (sceneName == "ProofTitle" && !hasSwitched) {
				SceneManager.LoadScene ("ProofStartScene");
				sceneName = thisScene.name;
                hasSwitched = true;
                ProofGameController.Instance.moveToNextLevel = false;
            }
            else if (sceneName == "ProofChildhood" && !hasSwitched) {
				SceneManager.LoadScene ("ProofVictoryScene");
				sceneName = thisScene.name;
                hasSwitched = true;
                ProofGameController.Instance.moveToNextLevel = false;
            }

        }

		if (ProofGameController.Instance.gameOver && !ProofGameController.Instance.moveToNextLevel) {
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
