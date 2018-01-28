using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScript : MonoBehaviour {
    float showTime;
    public UnityEngine.UI.Image displayImage;
    public UnityEngine.UI.Image textImage;

    public Sprite[] displayImages;
    public Sprite[] textImages;

	// Use this for initialization
	void Start () {
        showTime = Time.time;
        StartCoroutine(DisplayOpener());
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - showTime >= 3f && Input.GetButton("Submit"))
        {
            SceneManager.LoadScene("Environment");
            StopCoroutine(DisplayOpener());
        }
	}

    IEnumerator DisplayOpener()
    {
        textImage.gameObject.SetActive(false);
        for (int i = 0; i < Mathf.Max(displayImages.Length, textImages.Length); i++)
        {
            if (displayImages.Length > i)
            {
                displayImage.gameObject.SetActive(true);
                displayImage.sprite = displayImages[i];
                yield return new WaitForSecondsRealtime(4);
                displayImage.gameObject.SetActive(false);
            }

            if (textImages.Length > i)
            {
                textImage.gameObject.SetActive(true);
                textImage.sprite = textImages[i];
                yield return new WaitForSecondsRealtime(4);
                textImage.gameObject.SetActive(false);
            }
        }
        yield return null;
        SceneManager.LoadScene("Environment");        
    }
}
