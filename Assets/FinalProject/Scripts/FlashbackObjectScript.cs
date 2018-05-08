using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashbackObjectScript : MonoBehaviour {
    Vector3 myScale;
    float rateToInflate = 0.05f;
    GameObject player;
    bool satisfied = false;
    bool failed = false;
    float loveToGive = 0;
    GameObject line;
    GameObject FeckinSquare;
    public List<GameObject> lineList= new List<GameObject>();
    // Use this for initialization
    void Start () {
        myScale = new Vector3(0.1f, 0.1f, 0f);
        this.transform.localScale = myScale;
        player = GameObject.Find("Little Boy");
        line = ReconnectionGameController.Instance.lineExample;

    }
	
	// Update is called once per frame
	void Update () {
        
        this.transform.localScale = myScale;
        this.transform.position += new Vector3(0.0005f, 0, 0);
        if (myScale.x < .9f)
        {
            myScale += new Vector3(rateToInflate,rateToInflate, 0);
        }
        string myKeyToPress = this.transform.GetChild(0).GetComponent<TextMesh>().text;
        KeyCode[] keyToNotHit = ReconnectionGameController.Instance.DetermineKeysNotToPress(ReconnectionGameController.Instance.DetermineKeyToPress(myKeyToPress));
        foreach (KeyCode key in keyToNotHit)
        {
            if (Input.GetKeyDown(key))
            {
                failed = true;
            }
        }
        if (Mathf.Abs(this.transform.position.x - player.transform.position.x) < 4.5 && this.transform.position.x - player.transform.position.x > -4.35)
        {
            //Debug.Log("Close Enuogh");
            
            this.transform.GetChild(0).GetComponent<TextMesh>().color = Color.green;
           
            if (Input.GetKey(ReconnectionGameController.Instance.DetermineKeyToPress(myKeyToPress)) && !satisfied && !failed)
            {
                loveToGive++;
                GameObject myCoolLine=Instantiate(line, new Vector3(GameObject.Find("Little Boy").transform.position.x, GameObject.Find("Little Boy").transform.position.y + 2.95f, GameObject.Find("Little Boy").transform.position.z), Quaternion.identity);
              //  Debug.Log(myCoolLine);
                if (myCoolLine != null)
                {
                    lineList.Add(myCoolLine);
                }
            }
          
        }
        if(this.transform.position.x-player.transform.position.x<-8 && loveToGive==0)
        {
            

            if (ReconnectionGameController.Instance.love > 0)
            {
                ReconnectionGameController.Instance.love -= 50;
            }
            Debug.Log("You Suck");
          
            Destroy(this.gameObject);
        }
        if (this.transform.position.x - player.transform.position.x <-8 && loveToGive>0)        
        {
            
            ReconnectionGameController.Instance.sectionsPast++;
            if (ReconnectionGameController.Instance.love < 415)
            {
                ReconnectionGameController.Instance.love += loveToGive;
            }
            Debug.Log("Nailed It");
            loveToGive = 0;
            foreach (GameObject myLine in lineList)
            {
                Destroy(myLine.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
