using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneHandler : MonoBehaviour {
    public GameObject cutsceneCanvas;
    public bool imageOn=false;
    public int cutsceneLength = 4;
    public Image[] cutsceneImages;
    int imagesOn = 0;
	// Use this for initialization
	void Start () {
        cutsceneCanvas = GameObject.Find("CutsceneCanvas");
        cutsceneImages = new Image[cutsceneLength];
        for (int i = 0; i < cutsceneCanvas.transform.childCount; i++)
        {
           // Debug.Log("Added Image");
            //Debug.Log(cutsceneCanvas.transform.GetChild(i).GetComponent<Image>());
            Color temp= cutsceneCanvas.transform.GetChild(i).GetComponent<Image>().material.color;
            temp.a = 0;
            cutsceneCanvas.transform.GetChild(i).GetComponent<Image>().material.color = temp;
            cutsceneImages[i] = cutsceneCanvas.transform.GetChild(i).GetComponent<Image>();
        }
        TurnOnImage(ref cutsceneImages[imagesOn]);
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && imagesOn<cutsceneImages.Length){
            imageOn = false;
            TurnOnImage(ref cutsceneImages[imagesOn]);
        }
	}



    public void TurnOnImage(ref Image imageToSwitch)
    {
        Material tempMat = imageToSwitch.material;
        Color temp = tempMat.color;
        float opacity = 0;
        while (!imageOn)
        {
            opacity = Mathf.Lerp(opacity, 1f, 0.00001f);
            temp.a = opacity;
            tempMat.color = temp;
            imageToSwitch.material=tempMat;
           
            if (opacity > 0.99f)
            {
                imageOn = true;
                imagesOn++;
            }
        }
       
        return;
    }
}
