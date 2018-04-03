using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TestSceneManager : MonoBehaviour {
    string sceneName;
    Scene thisScene;
	// Use this for initialization
	void Start () {
        thisScene = SceneManager.GetActiveScene();
        sceneName = thisScene.name;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(sceneName);

        }
	}
}
