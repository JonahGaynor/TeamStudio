using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagementScript : MonoBehaviour {
   public int levelsPast=0;
	Scene thisScene;
	string sceneName;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        levelsPast++;
		thisScene = SceneManager.GetActiveScene();
		sceneName = thisScene.name;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.R)) {
            SceneManager.LoadScene("ChildhoodScene");
            levelsPast = 1;
			thisScene = SceneManager.GetActiveScene();
			sceneName = thisScene.name;
        }
        if (GameController.Instance.moveToNextLevel && GameController.Instance.topChoiceMade&&this.levelsPast==1)
        {
            levelsPast++;
            GameController.Instance.moveToNextLevel = false;
            GameController.Instance.topChoiceMade = false;
            SceneManager.LoadScene("SportsScene");
			thisScene = SceneManager.GetActiveScene();
			sceneName = thisScene.name;
        }
        if (GameController.Instance.moveToNextLevel && GameController.Instance.bottomChoiceMade && this.levelsPast == 1)
        {
            levelsPast++;
            GameController.Instance.moveToNextLevel = false;
            GameController.Instance.bottomChoiceMade = false;
            SceneManager.LoadScene("ChildChoiceScene");
			thisScene = SceneManager.GetActiveScene();
			sceneName = thisScene.name;
        }
		if (GameController.Instance.moveToNextLevel && GameController.Instance.topChoiceMade && this.levelsPast == 2 && sceneName == "SportsScene")
        {
            levelsPast++;
            SceneManager.LoadScene("SadSportsScene");
			thisScene = SceneManager.GetActiveScene();
			sceneName = thisScene.name;
          //  GameController.Instance.levelsPast++;
        }
		if (GameController.Instance.moveToNextLevel && GameController.Instance.bottomChoiceMade && this.levelsPast == 2 && sceneName == "SportsScene")
		{
			levelsPast++;
			SceneManager.LoadScene("HappySportsEnding");
			thisScene = SceneManager.GetActiveScene();
			sceneName = thisScene.name;
			//  GameController.Instance.levelsPast++;
		}
		if (GameController.Instance.moveToNextLevel && GameController.Instance.topChoiceMade && this.levelsPast == 2 && sceneName == "ChildChoiceScene")
		{
			levelsPast++;
			SceneManager.LoadScene("SadScene");
			thisScene = SceneManager.GetActiveScene();
			sceneName = thisScene.name;
			//  GameController.Instance.levelsPast++;
		}
		if (GameController.Instance.moveToNextLevel && GameController.Instance.bottomChoiceMade && this.levelsPast == 2 && sceneName == "ChildChoiceScene")
        {
            levelsPast++;
            SceneManager.LoadScene("HappyEnding");
			thisScene = SceneManager.GetActiveScene();
			sceneName = thisScene.name;
          //  GameController.Instance.levelsPast++;
        }
    }

}
