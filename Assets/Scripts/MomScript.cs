using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomScript : MonoBehaviour {
    public GameObject player;
     int offset = 9;
    public float placeToGo;
    public SpriteRenderer momVersion;
    public Sprite[] momSprites;
   
    // Use this for initialization
    void Start()
    {
        momVersion = this.GetComponent<SpriteRenderer>();
        momVersion.sprite = momSprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        offset = GameController.Instance.life;

        placeToGo = player.transform.position.x - offset-1;
            Vector3 temp = this.transform.position;

        if (GameController.Instance.gameOver)
        {
            momVersion.sprite = momSprites[1];
        }

            if (this.transform.position.x < placeToGo)
            {
                temp.x += GameController.Instance.standardMoveSpeed*1.25f;
            }
            else
            {
                if (!GameController.Instance.gameOver && (!GameController.Instance.hitText || GameController.Instance.escapeTime))
                {
               
                temp.x += GameController.Instance.standardMoveSpeed;
                }
            }
        
       // temp.x = player.transform.position.x - offset;
        this.transform.position = temp;
    }
}
