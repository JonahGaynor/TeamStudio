using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTitle : MonoBehaviour {
    bool fadeToEnd = false;
    bool fadeToStart = true;
    public Material fadeToBlack;
    Color temporary;
    public float opacityBlack = 0f;
    // Update is called once per frame
    private void Start()
    {
        fadeToBlack = GameObject.Find("Main Camera").transform.GetChild(0).GetComponent<Renderer>().material;
        temporary = fadeToBlack.color;
        opacityBlack = temporary.a;
        Debug.Log("Opacity: "+opacityBlack);
    }

    void Update () {
       
        if (fadeToStart)
        {
            temporary = fadeToBlack.color;
            temporary.a = opacityBlack;
            Debug.Log(opacityBlack);
            fadeToBlack.color = temporary;
            Debug.Log("Changing Opacity");
            opacityBlack = Mathf.Lerp(opacityBlack, 0, .03f);

            if (opacityBlack < 0.1f)
            {
                fadeToStart = false;
            }
        }

       
            if (Input.GetKeyUp(KeyCode.Return)&&!fadeToStart)
            {
                ProofGameController.Instance.fadeToEnd = true;
            }

            if (GameObject.Find("Blocker").GetComponent<SpriteRenderer>().material.color.a >= 0.9f)
            {
                ProofGameController.Instance.moveToNextLevel = true;
            }
	}
}
