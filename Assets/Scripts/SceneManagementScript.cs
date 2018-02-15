using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagementScript : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.R)) {
            SceneManager.LoadScene("runScene");
        }
        if (GameController.Instance.moveToNextLevel && GameController.Instance.topChoiceMade&&GameController.Instance.levelsPast==0)
        {
            GameController.Instance.levelsPast++;
            GameController.Instance.moveToNextLevel = false;
            GameController.Instance.topChoiceMade = false;
            SceneManager.LoadScene("SportsScene");
            
        }
        if (GameController.Instance.moveToNextLevel && GameController.Instance.bottomChoiceMade && GameController.Instance.levelsPast == 0)
        {
            GameController.Instance.levelsPast++;
            GameController.Instance.moveToNextLevel = false;
            GameController.Instance.bottomChoiceMade = false;
            SceneManager.LoadScene("ScienceScene");
            
        }
        if (GameController.Instance.moveToNextLevel && GameController.Instance.topChoiceMade && GameController.Instance.levelsPast == 1)
        {
            SceneManager.LoadScene("SadScene");
            GameController.Instance.levelsPast++;
        }
        if (GameController.Instance.moveToNextLevel && GameController.Instance.bottomChoiceMade && GameController.Instance.levelsPast == 1)
        {
            SceneManager.LoadScene("HappyEnding");
            GameController.Instance.levelsPast++;
        }
    }

}
