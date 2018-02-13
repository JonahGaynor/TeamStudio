using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagementScript : MonoBehaviour {



    void Update()
    {

        if (Input.GetKey(KeyCode.R)) {
            SceneManager.LoadScene("runScene");
        }
    }

}
