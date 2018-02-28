using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagementScript : MonoBehaviour {
   public int levelsPast=1;
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
		thisScene = SceneManager.GetActiveScene();
		sceneName = thisScene.name;
        if (Input.GetKey(KeyCode.R)) {
            SceneManager.LoadScene("HomeScene");
            levelsPast = 1;
			thisScene = SceneManager.GetActiveScene();
			sceneName = thisScene.name;
        }
        if (SixLaneGameController.Instance.moveToNextLevel && SixLaneGameController.Instance.topChoiceMade&&this.levelsPast==1)
        {
            levelsPast++;
            SixLaneGameController.Instance.moveToNextLevel = false;
            SixLaneGameController.Instance.topChoiceMade = false;
            SceneManager.LoadScene("LoveScene");
			thisScene = SceneManager.GetActiveScene();
			sceneName = thisScene.name;
        }
        if (SixLaneGameController.Instance.moveToNextLevel && SixLaneGameController.Instance.bottomChoiceMade && this.levelsPast == 1)
        {
            levelsPast++;
            SixLaneGameController.Instance.moveToNextLevel = false;
            SixLaneGameController.Instance.bottomChoiceMade = false;
            SceneManager.LoadScene("FlashlightScene");
			thisScene = SceneManager.GetActiveScene();
			sceneName = thisScene.name;
        }
		if (SixLaneGameController.Instance.moveToNextLevel && SixLaneGameController.Instance.topChoiceMade && this.levelsPast == 2 && sceneName == "SportsScene")
        {
            levelsPast++;
            SceneManager.LoadScene("SadSportsScene");
			thisScene = SceneManager.GetActiveScene();
			sceneName = thisScene.name;
          //  GameController.Instance.levelsPast++;
        }
		if (SixLaneGameController.Instance.moveToNextLevel && SixLaneGameController.Instance.bottomChoiceMade && this.levelsPast == 2 && sceneName == "SportsScene")
		{
			levelsPast++;
			SceneManager.LoadScene("HappySportsEnding");
			thisScene = SceneManager.GetActiveScene();
			sceneName = thisScene.name;
			//  GameController.Instance.levelsPast++;
		}
		if (SixLaneGameController.Instance.moveToNextLevel && SixLaneGameController.Instance.topChoiceMade && this.levelsPast == 2 && sceneName == "ScienceScene")
		{
			levelsPast++;
			SceneManager.LoadScene("SadScene");
			thisScene = SceneManager.GetActiveScene();
			sceneName = thisScene.name;
			//  GameController.Instance.levelsPast++;
		}
		if (SixLaneGameController.Instance.moveToNextLevel && SixLaneGameController.Instance.bottomChoiceMade && this.levelsPast == 2 && sceneName == "ScienceScene")
        {
            levelsPast++;
            SceneManager.LoadScene("HappyEnding");
			thisScene = SceneManager.GetActiveScene();
			sceneName = thisScene.name;
          //  GameController.Instance.levelsPast++;
        }
		if (ScaryGameController.Instance.gameOver || SixLaneGameController.Instance.gameOver) {
			SceneManager.LoadScene ("LoseScene");
		}
		if (SixLaneGameController.Instance.weWon) {
			SceneManager.LoadScene ("WinScene");
		}
		if (thisScene.name == "LoseScene" && Input.GetKey(KeyCode.Return)) {
			SceneManager.LoadScene ("StartScene");
		}
		if (thisScene.name == "WinScene" && Input.GetKey(KeyCode.Return)) {
			SceneManager.LoadScene ("StartScene");
		}
    }

}
