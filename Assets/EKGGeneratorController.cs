using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EKGGeneratorController : MonoBehaviour {
    public float timeToSwitch;
    public GameObject bumpyGen;
    public GameObject dippyGen;
    public float minutesToSwitch=1;
	// Use this for initialization
	void Start () {
        bumpyGen = transform.Find("Choice Generator").gameObject;
        dippyGen= transform.Find("HoleGenerator").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        timeToSwitch += Time.deltaTime;
        if (timeToSwitch > 60 * minutesToSwitch)
        {
            bumpyGen.SetActive(false);
            dippyGen.SetActive(true);
        }



	}
}
