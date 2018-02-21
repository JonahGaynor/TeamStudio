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

	// Use this for initialization
	void Start () {
		thisScene = SceneManager.GetActiveScene();
		sceneName = thisScene.name;
	}
	
	// Update is called once per frame
	void Update () {
		thisScene = SceneManager.GetActiveScene();
		sceneName = thisScene.name;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (sceneName == "ChildhoodScene") {
			if (col.gameObject.name == "TV") {
				myRenderer.sprite = allSprites [1];
			}
			if (col.gameObject.name == "Bed") {
				myRenderer.sprite = allSprites [2];
			}
			if (col.gameObject.name == "Science") {
				SixLaneGameController.Instance.moveToNextLevel = true;
				SixLaneGameController.Instance.bottomChoiceMade = true;
			}
			if (col.gameObject.name == "Sports") {
				SixLaneGameController.Instance.moveToNextLevel = true;
				SixLaneGameController.Instance.topChoiceMade = true;
			}
		}
		if (sceneName == "ChildChoiceScene" || sceneName == "jonahScene2") {
			if (col.gameObject.name == "Mutate") {
				myRenderer.sprite = allSprites [1];
			}
			if (col.gameObject.name == "Grant") {
				for (int i = 0; i < 20; i++){
					Instantiate (moneySpawn, gameObject.transform);
				}
			}
			if (col.gameObject.name == "Career") {
				SixLaneGameController.Instance.moveToNextLevel = true;
				SixLaneGameController.Instance.topChoiceMade = true;
			}
			if (col.gameObject.name == "Family") {
				SixLaneGameController.Instance.moveToNextLevel = true;
				SixLaneGameController.Instance.bottomChoiceMade = true;
			}
		}
		if (sceneName == "SportsScene") {
			if (col.gameObject.name == "Steroids") {
				myRenderer.sprite = allSprites [1];
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
			if (col.gameObject.name == "Retire") {
				if (myRenderer.sprite == allSprites [5]) {
					SixLaneGameController.Instance.topChoiceMade = true;
					SixLaneGameController.Instance.moveToNextLevel = true;
				} else {
					SixLaneGameController.Instance.bottomChoiceMade = true;
					SixLaneGameController.Instance.moveToNextLevel = true;
				}
			}
		}
	}
}
