using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteSwitchScript : MonoBehaviour {

	public SpriteRenderer myRenderer;
	public Sprite[] allSprites;
	Scene thisScene;
	string sceneName;
	public GameObject moneySpawn;
    public GameObject outsideBG;
    public GameObject bgWithPics;

    // Use this for initialization
    void Start () {
        myRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		thisScene = SceneManager.GetActiveScene();
		sceneName = thisScene.name;
	}
	
	// Update is called once per frame
	void Update () {
		thisScene = SceneManager.GetActiveScene();
		sceneName = thisScene.name;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (sceneName == "ChildhoodScene"||sceneName== "Prototype2.5TestScene") {

            if (col.gameObject.name == "TV") {
              
				myRenderer.sprite = allSprites [1];
			}
			if (col.gameObject.name == "Bed") {
				myRenderer.sprite = allSprites [2];
               
            }
            if (col.gameObject.name == "Outside")
            {
                GameObject choiceGen = GameObject.Find("Choice Generator");
                SixLaneChoiceGen myScript = choiceGen.GetComponent<SixLaneChoiceGen>();
                myScript.backgrounds[0] = outsideBG;
              
            }
            if (col.gameObject.name == "Inside")
            {
                GameObject choiceGen = GameObject.Find("Choice Generator");
                SixLaneChoiceGen myScript = choiceGen.GetComponent<SixLaneChoiceGen>();
                myScript.backgrounds[0] = bgWithPics;

            }

            if (col.gameObject.name == "Science") {
				SixLaneGameController.Instance.spawnFadePrefab = true;
				SixLaneGameController.Instance.topChoiceMade = true;
			}
			if (col.gameObject.name == "Sports") {
				SixLaneGameController.Instance.spawnFadePrefab = true;
				SixLaneGameController.Instance.bottomChoiceMade = true;
			}
		}
		if (sceneName == "ChildChoiceScene" || sceneName == "ScienceScene") {
			if (col.gameObject.name == "Mutate") {
				myRenderer.sprite = allSprites [1];
			}
			if (col.gameObject.name == "Grant") {
				for (int i = 0; i < 20; i++){
					Instantiate (moneySpawn, this.gameObject.transform);
				}
			}
			if (col.gameObject.name == "Career") {
				SixLaneGameController.Instance.spawnFadePrefab = true;
				SixLaneGameController.Instance.topChoiceMade = true;
			}
			if (col.gameObject.name == "Family") {
				SixLaneGameController.Instance.spawnFadePrefab = true;
				SixLaneGameController.Instance.bottomChoiceMade = true;
			}
		}
		if (sceneName == "SportsScene") {
            Debug.Log("In Scene");
            if (col.gameObject.name == "Steroids") {
				myRenderer.sprite = allSprites [1];
                Debug.Log("Steriods");
			}
			if (col.gameObject.name == "NewTeam") {
				myRenderer.sprite = allSprites [2];
			}
			if (col.gameObject.name == "KeepPlaying1") {
				myRenderer.sprite = allSprites [3];
			}
			if (col.gameObject.name == "KeepPlaying2") {
				myRenderer.sprite = allSprites [4];
			}
			if (col.gameObject.name == "KeepPlaying3") {
				myRenderer.sprite = allSprites [5];

			}
            if (col.gameObject.name == "KeepPlaying3"&& myRenderer.sprite == allSprites[5])
            {
                SixLaneGameController.Instance.topChoiceMade = true;
                SixLaneGameController.Instance.spawnFadePrefab = true;
            }
            if (col.gameObject.name == "Retire") {
				if (myRenderer.sprite == allSprites [5]) {
					SixLaneGameController.Instance.topChoiceMade = true;
					SixLaneGameController.Instance.spawnFadePrefab = true;
				} else {
					SixLaneGameController.Instance.bottomChoiceMade = true;
					SixLaneGameController.Instance.spawnFadePrefab = true;
				}
			}
		}
	}
}
