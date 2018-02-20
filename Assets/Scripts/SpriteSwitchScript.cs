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
		}
		if (sceneName == "ChildChoiceScene") {
			if (col.gameObject.name == "Mutate") {
				myRenderer.sprite = allSprites [1];
			}
			if (col.gameObject.name == "Grant") {
				for (int i = 0; i < 10; i++){
					Instantiate (moneySpawn, gameObject.transform);
				}
			}
		}
		if (sceneName == "SportsScene") {
			if (col.gameObject.name == "Steroids") {
				myRenderer.sprite = allSprites [1];
			}
			if (col.gameObject.name == "NewTeam") {
				myRenderer.sprite = allSprites [2];
			}
			if (col.gameObject.name == "Retire1") {
				myRenderer.sprite = allSprites [3];
			}
			if (col.gameObject.name == "Retire2") {
				myRenderer.sprite = allSprites [4];
			}
			if (col.gameObject.name == "Retire3") {
				myRenderer.sprite = allSprites [5];
			}
		}
	}
}
