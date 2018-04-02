using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public GameObject player;
    public float offset = -4;
	public Material fadeToBlack;
	public float opacityBlack = 0f;
    public float opacityWhite = 0f;
    Color temporary;
	//public bool fadeToWhite = false;
	float lerpTo = 0;
    public Material fadeToWhite;
    public float waitTime=0;
	// Use this for initialization
	void Start () {
		fadeToBlack = this.transform.GetChild(0).GetComponent<Renderer>().material;
        fadeToWhite = this.transform.GetChild(1).GetComponent<Renderer>().material;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 temp = this.transform.position;
        temp.x = player.transform.position.x-offset;
        this.transform.position = temp;


		temporary = fadeToBlack.color;
		temporary.a = opacityBlack;
		 fadeToBlack.color = temporary;
        Color tempWhite = fadeToWhite.color;
        tempWhite.a = opacityWhite;
        fadeToWhite.color = tempWhite;

		if (ProofGameController.Instance.fadeToEnd) {
            //			StartCoroutine (GetFaded ());
            //  Debug.Log("Fading");
            opacityBlack = Mathf.Lerp (opacityBlack, 255, .00003f);
           // Debug.Log(opacityBlack);
            if (opacityBlack >= 0.9)
            {
                waitTime += Time.deltaTime;
                if (waitTime > 0.3f)
                {
                    Debug.Log("Trying White");
                    opacityWhite = Mathf.Lerp(opacityWhite, 255, .00003f);
                }
            }



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

	/*IEnumerator GetFaded(){
      //  Debug.Log("Fading");
		lerpTo = 255;
		opacity = 0f;
		yield return new WaitForSeconds (1.5f);
		opacity = 0f;
		temporary = Color.white;
		fadeToBlack.color = Color.white;
	}*/

   

}
