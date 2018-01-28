using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MessageDisplayScript : MonoBehaviour
{
    public Text mainMessage;
    public GameObject mainPanel;
    public Image leftProfile;
    public Image rightProfile;
    public Image FocusImage;
    public GameObject OptionPanel;
    public Text Option1;
    public Text Option2;
    public RawImage AImage;
    public RawImage BImage;
    
    // Use this for initialization
    void Start()
    {
        HideMessage();
    }

    public void ShowMessage(string[] textPages, bool isBlocking)
    {
        mainPanel.SetActive(true);
        if (isBlocking)
        {
            Time.timeScale = 0;
            StartCoroutine(DoMessage(textPages));
        }
        else
        {

        }
        
    }

    public void ShowProximityMessage(string text)
    {
        mainPanel.SetActive(true);
        mainMessage.text = text;
    }

    public IEnumerator DoMessage(string[] textPages)
    {
        foreach (string t in textPages)
        {
            mainMessage.text = t;
            do
            {
                yield return null;
            } while (!Input.GetButtonDown("Submit"));
        }
        HideMessage();
    }

    /*
    //set textDelay=0 to show instantly
    public void ShowMessage(string text, float textDelay, Sprite leftSprite = null, Sprite rightSprite = null)
    {
        
        if (leftSprite != null)
        {
            leftProfile.sprite = leftSprite;
            leftProfile.gameObject.SetActive(true);
        }
        if (rightSprite != null)
        {
            rightProfile.gameObject.SetActive(true);
            rightProfile.sprite = rightSprite;
        }
        
        if (textDelay == 0)
        {
            mainMessage.text = text;
            mainPanel.SetActive(true);
        }
        
        else
        {
            //mainPanel.SetActive(true);
            //StartCoroutine(SlowWriteText(text, textDelay));
        }
        
    }
    */
    /*
    public void ShowMessageForSeconds(string text, float duration, Sprite leftSprite = null, Sprite rightSprite = null)
    {
        ShowMessage(text, 0);
        StartCoroutine(CloseMessageAfterSeconds(duration));
    }

    IEnumerator SlowWriteText(string text, float textDelay)
    {
        mainMessage.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            yield return new WaitForSecondsRealtime(textDelay);
            mainMessage.text += text[i];
        }
    }
    private IEnumerator CloseMessageAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        HideMessage();
    }
    */

    public void HideMessage()
    {
        mainPanel.SetActive(false);
        leftProfile.gameObject.SetActive(false);
        rightProfile.gameObject.SetActive(false);
        FocusImage.gameObject.SetActive(false);
        OptionPanel.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void ShowPrompt(string[] textPages, string finalPrompt, string opt1, string opt2, System.Action<int> callback)
    {
        Debug.Log("showprompt");
        StartCoroutine(ShowMultipagePrompt(textPages, finalPrompt,opt1, opt2, callback));
    }

    private IEnumerator ShowMultipagePrompt(string[] textPages,string finalPrompt, string opt1, string opt2, System.Action<int> callback)
    {
        Time.timeScale = 0;
        mainPanel.SetActive(true);
        foreach (string t in textPages)
        {
            mainMessage.text = t;
            do
            {
                yield return null;
            } while (!Input.GetButtonDown("Submit"));
        }
        if (finalPrompt.Length > 0)
        {
            StartCoroutine(DoPrompting(finalPrompt, opt1, opt2, callback));
        }
        else
        {
            Time.timeScale = 1;
            HideMessage();
        }
    }

    private IEnumerator DoPrompting(string text, string opt1, string opt2, System.Action<int> callback)
    {
        Time.timeScale = 0;
        mainMessage.text = text;
        OptionPanel.SetActive(true);
        Option1.text = opt1;
        Option2.text = opt2;
        while (true)
        {
            if (Input.GetButtonDown("Option1"))
            {
                HideMessage();
                callback(1);
                yield break;
            }
            else if (Input.GetButtonDown("Option2"))
            {
                HideMessage();
                callback(1);
                yield break;
            }
            else
            {
                yield return null;
            }
        }
    }
}
