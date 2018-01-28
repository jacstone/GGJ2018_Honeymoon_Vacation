using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLoader : MonoBehaviour {
    public Text endingText;
    public GameObject deathImage;
    public GameObject lifeImage;
    private float showTime;

	// Use this for initialization
	void Start () {
        endingText.text = DataMover.FinalMessage;
        deathImage.SetActive(DataMover.isDeath);
        lifeImage.SetActive(!DataMover.isDeath);
        showTime = Time.time;
	}

    private void Update()
    {
        if (Time.time - showTime >= 3f && Input.GetButton("Submit"))
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
