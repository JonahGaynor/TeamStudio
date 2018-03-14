using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SixLaneUIController : MonoBehaviour {
    public Sprite heart;
    public GameObject heartImage;
    public int health;
    public GameObject myCanvas;
    int startingX=50;
    int startingY=380;
    GameObject[] hearts;
    // Use this for initialization
    void Start () {
        health = SixLaneGameController.Instance.life;
        myCanvas = GameObject.Find("Canvas");
        for (int i = 0; i < health+50; i++)
        {
            GameObject temp = Instantiate(heartImage);
            Image heartRend = temp.GetComponent<Image>();
            heartRend.sprite = heart;
            Vector3 tempPos = temp.transform.position;
            tempPos.x = startingX + 20 * i;
            tempPos.y = startingY;
            temp.transform.position = tempPos;
            temp.transform.parent = myCanvas.transform;
        }
        hearts = GameObject.FindGameObjectsWithTag("Heart");
    }
	
	// Update is called once per frame
	void Update () {
       
        foreach (GameObject heart in hearts)
        {
            heart.SetActive(false);
        }
        health = SixLaneGameController.Instance.life;
        for (int i = 0; i < health; i++)
        {
            /*GameObject temp = Instantiate(heartImage);
            Vector3 tempPos = temp.transform.position;
            tempPos.x = startingX +20 * i;
            tempPos.y = startingY;
            temp.transform.position = tempPos;
            temp.transform.parent = myCanvas.transform;*/
            hearts[i].gameObject.SetActive(true);
        }

        
    }
}
