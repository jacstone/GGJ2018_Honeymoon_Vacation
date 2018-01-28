using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour {
    float showTime;
	// Use this for initialization
	void Start () {
        showTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - showTime >= 3f && Input.GetButton("Submit"))
        {
            SceneManager.LoadScene("Opening");
        }

    }
}
