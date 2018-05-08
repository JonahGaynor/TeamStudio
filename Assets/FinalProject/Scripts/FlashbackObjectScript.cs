using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashbackObjectScript : MonoBehaviour {
    Vector3 myScale;
    float rateToInflate = 0.05f;
    GameObject player;
    bool satisfied = false;
    // Use this for initialization
    void Start () {
        myScale = new Vector3(0.1f, 0.1f, 0f);
        this.transform.localScale = myScale;
        player = GameObject.Find("Little Boy");
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.localScale = myScale;
        this.transform.position += new Vector3(0.0005f, 0, 0);
        if (myScale.x < 0.75)
        {
            myScale += new Vector3(rateToInflate,rateToInflate, 0);
        }

        if (Mathf.Abs(this.transform.position.x - player.transform.position.x) < 3)
        {
            //Debug.Log("Close Enuogh");
            string myKeyToPress = this.transform.GetChild(0).GetComponent<TextMesh>().text;
            this.transform.GetChild(0).GetComponent<TextMesh>().color = Color.green;
            if (Input.GetKeyDown(ReconnectionGameController.Instance.DetermineKeyToPress(myKeyToPress)))
            {
                satisfied = true;
                ReconnectionGameController.Instance.love+=50;
            }
        }
        if(this.transform.position.x-player.transform.position.x<-3.25 && !satisfied)
        {
            ReconnectionGameController.Instance.sectionsPast++;
            ReconnectionGameController.Instance.love-=50;
            Debug.Log("You Suck");
            Destroy(this.gameObject);
        }
        if (this.transform.position.x - player.transform.position.x <-3.25 && satisfied)        
        {
            ReconnectionGameController.Instance.sectionsPast++;
            Debug.Log("Nailed It");
            Destroy(this.gameObject);
        }
    }
}
