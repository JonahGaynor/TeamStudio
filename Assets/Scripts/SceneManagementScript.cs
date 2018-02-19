using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagementScript : MonoBehaviour {
   public int levelsPast=0;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        levelsPast++;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.R)) {
            SceneManager.LoadScene("ChildhoodScene");
            levelsPast = 1;
        }
        if (GameController.Instance.moveToNextLevel && GameController.Instance.topChoiceMade&&this.levelsPast==1)
        {
            levelsPast++;
            GameController.Instance.moveToNextLevel = false;
            GameController.Instance.topChoiceMade = false;
            SceneManager.LoadScene("SportsScene");
            
        }
        if (GameController.Instance.moveToNextLevel && GameController.Instance.bottomChoiceMade && this.levelsPast == 1)
        {
            levelsPast++;
            GameController.Instance.moveToNextLevel = false;
            GameController.Instance.bottomChoiceMade = false;
            SceneManager.LoadScene("ChildChoiceScene");
            
        }
        if (GameController.Instance.moveToNextLevel && GameController.Instance.topChoiceMade && this.levelsPast == 2)
        {
            levelsPast++;
            SceneManager.LoadScene("SadScene");
          //  GameController.Instance.levelsPast++;
        }
        if (GameController.Instance.moveToNextLevel && GameController.Instance.bottomChoiceMade && this.levelsPast == 2)
        {
            levelsPast++;
            SceneManager.LoadScene("HappyEnding");
          //  GameController.Instance.levelsPast++;
        }
    }

}
