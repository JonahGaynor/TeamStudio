using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CameraControlScript : MonoBehaviour {

    //intended features:
    // 1. follow child but factor in mother's position
    // 2. when mom lands, shake screen.
    public Material fadeToBlack;
	public Transform kid;
	public Transform mom;
     float shake = 0.05f;
    int cameraOffset = 6;
    public float startingy;
    Vector3 kidLocation;
    Vector3 momLocation;
	float maxShakeX;
	float minShakeX;
	float maxShakeY;
	float minShakeY;
    float opacity = 0;
    public GameObject funeralScene;
	MomMovementScript mommaScript;


	// Use this for initialization
	void Start () {
        fadeToBlack = this.transform.GetChild(0).GetComponent<Renderer>().material;
		 mommaScript = mom.GetComponent<MomMovementScript>();
        kidLocation = kid.transform.position;
         momLocation = mom.transform.position;
         maxShakeX = shake;
         minShakeX = -shake;
         maxShakeY = shake;
         minShakeY = -shake;
        startingy = this.transform.position.y;
    }

	// Update is called once per frame
	void Update () {
        Color temp = fadeToBlack.color;
        temp.a = opacity;
        fadeToBlack.color = temp;
        mommaScript = mom.GetComponent<MomMovementScript>();
        kidLocation = kid.transform.position;
        momLocation = mom.transform.position;
        if (GameController.Instance.fadeToEnd)
        {
            opacity = Mathf.Lerp(opacity, 255, .00001f);
        }

        if (!GameController.Instance.atFuneral)
        {
            if (!mommaScript.didLand)
            {
                transform.position = new Vector3((kidLocation.x * 3 + momLocation.x) / 4 + cameraOffset, startingy, transform.position.z);
            }
            if (mommaScript.didLand)
            {

                float shakeX = Random.Range(minShakeX, maxShakeX);
                float shakeY = Random.Range(minShakeY, maxShakeY);

                transform.position = new Vector3((kidLocation.x * 3 + momLocation.x) / 4 + shakeX + cameraOffset, transform.position.y + shakeY, transform.position.z);
            }
           
        }
        else
        {
           Vector3 temppos = this.transform.position;
            temppos.x = Mathf.Lerp(temppos.x, funeralScene.transform.position.x, 0.025f);
            temppos.y = Mathf.Lerp(temppos.y, funeralScene.transform.position.y, 0.025f);
            this.transform.position = temppos;
        }


	}
}
