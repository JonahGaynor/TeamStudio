using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour {
    public static SliderController Instance = new SliderController();
    public Slider healthSlider;
	// Use this for initialization
	void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveSliderForward(float distanceToMove)
    {

        healthSlider.value += distanceToMove;

    }
}
