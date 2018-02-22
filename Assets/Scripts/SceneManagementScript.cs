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
        levelsPast = 2;
        if (Input.GetKey(KeyCode.R)) {
            SceneManager.LoadScene("ChildhoodScene");
            levelsPast = 1;
			thisScene = SceneManager.GetActiveScene();
			sceneName = thisScene.name;
        }
        if (SixLaneGameController.Instance.moveToNextLevel && SixLaneGameController.Instance.topChoiceMade&&this.levelsPast==1)
        {
            levelsPast++;
            SixLaneGameController.Instance.moveToNextLevel = false;
            SixLaneGameController.Instance.topChoiceMade = false;
            SceneManager.LoadScene("SportsScene");
			thisScene = SceneManager.GetActiveScene();
			sceneName = thisScene.name;
        }
        if (SixLaneGameController.Instance.moveToNextLevel && SixLaneGameController.Instance.bottomChoiceMade && this.levelsPast == 1)
        {
            levelsPast++;
            SixLaneGameController.Instance.moveToNextLevel = false;
            SixLaneGameController.Instance.bottomChoiceMade = false;
            SceneManager.LoadScene("ChildChoiceScene");
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
    }

}
