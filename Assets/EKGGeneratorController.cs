using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EKGGeneratorController : MonoBehaviour {
    public float timeToSwitch=0;
    public GameObject bumpyGen;
    public GameObject dippyGen;
    public float minutesToSwitch=1;
	// Use this for initialization
	void Start () {
        bumpyGen = transform.Find("Blips Generator").gameObject;
        dippyGen= transform.Find("HoleGenerator").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        timeToSwitch += Time.deltaTime;
        if (!ProofGameController.Instance.fadeToEnd)
        {
            if (timeToSwitch > 60 * minutesToSwitch && bumpyGen.activeInHierarchy == true)
            {
                bumpyGen.SetActive(false);
                dippyGen.SetActive(true);
                timeToSwitch = 0;
            }
            if (timeToSwitch > 60 * minutesToSwitch && bumpyGen.activeInHierarchy == false)
            {
                bumpyGen.SetActive(true);
                dippyGen.SetActive(false);
                timeToSwitch = 0;
            }
        }
        if (ProofGameController.Instance.fadeToEnd)
        {
            bumpyGen.SetActive(false);
            dippyGen.SetActive(false);
        }



    }
}
