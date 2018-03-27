using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public GameObject player;
    public int offset = -4;
	public Material fadeToBlack;
	public float opacity = 0f;
	Color temporary;
	public bool fadeToWhite = false;
	float lerpTo = 0;

	// Use this for initialization
	void Start () {
		fadeToBlack = this.transform.GetChild(0).GetComponent<Renderer>().material;

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 temp = this.transform.position;
        temp.x = player.transform.position.x-offset;
        this.transform.position = temp;


		temporary = fadeToBlack.color;
		temporary.a = opacity;
		fadeToBlack.color = temporary;   
	
		if (ProofGameController.Instance.fadeToEnd) {
//			StartCoroutine (GetFaded ());
			opacity = Mathf.Lerp (opacity, 255, .00003f);
//			Debug.Log (opacity);
//			if (opacity >= 0.0255) {
//				fadeToWhite = true;
//			}
//			if (fadeToWhite) {
//				opacity = 0f;
//				temporary = Color.white;
//				fadeToBlack.color = Color.white;
//				this.transform.GetChild (0).GetComponent<Renderer> ().material.color = Color.white;
//			}
		}
//		opacity = Mathf.Lerp (opacity, lerpTo, .0001f);
	}

	IEnumerator GetFaded(){
		lerpTo = 255;
		opacity = 0f;
		yield return new WaitForSeconds (1.5f);
		opacity = 0f;
		temporary = Color.white;
		fadeToBlack.color = Color.white;
	}

    public void startFade()
    {
        opacity = Mathf.Lerp(opacity, 255, .00003f);
    }

}
