using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDecisionScript : MonoBehaviour
{

    public float moveSpeed = .3f;
    public Transform myTarget;
    Vector3 playerOffset;
    bool readyToBounce = false;
    float originalY;
    bool drop = false;
    float xoffset = 10f;

    // Use this for initialization
    void Start()
    {
        playerOffset = new Vector3(0f, 0f, 0f);
        originalY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, myTarget.position + playerOffset, moveSpeed);
        if (playerOffset.y == 0f)
        {
            transform.position = new Vector3(transform.position.x, originalY, 0f);
        }
        if ((transform.position.x <= myTarget.position.x + 2f)&&!drop)
        {
            playerOffset = new Vector3(xoffset, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            drop = true;
            playerOffset = new Vector3(xoffset, -10f, 0f);
            
        }
    }

}