using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityIndicator : MonoBehaviour {
    public GameObject IndicatorCanvas;
    public string ProximityMessage;
    private MessageDisplayScript MessageDisplayScript;
    public bool IsTriggered;
    public string[] InspectionText;
    public string InspectionPrompt;
    public string Option1;
    public string Option2;
    public string[] Option1Response;
    public string[] Option2Response;
    public GameStates.States Option1GameState;
    public GameStates.States Option2GameState;
    public bool UseOption1GameState;
    public bool UseOption2GameState;

    private bool CanInteract;
    
    private PickUpCollactable CollectScript;

    void Start()
    {
        MessageDisplayScript = GameObject.FindGameObjectWithTag("UI").GetComponent<MessageDisplayScript>() as MessageDisplayScript;
        CollectScript = GetComponent<PickUpCollactable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsTriggered = true;
            if (IndicatorCanvas != null)
            {
                IndicatorCanvas.SetActive(true);
                MessageDisplayScript.ShowProximityMessage(ProximityMessage);
                CanInteract = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsTriggered = false;
            if (IndicatorCanvas != null)
            {
                IndicatorCanvas.SetActive(false);
                MessageDisplayScript.HideMessage();
            }
        }
    }

    private void FixedUpdate()
    {
        if (IsTriggered && gameObject.activeSelf && Input.GetButton("Submit") && CanInteract)
        {
            CanInteract = false;
            if (InspectionPrompt.Length > 0)
            {
                MessageDisplayScript.ShowPrompt(InspectionText, InspectionPrompt, Option1, Option2, HandlePromptResponse);
            }
            else
            {
                MessageDisplayScript.ShowMessage(InspectionText, true);
            }
        }
    }

    private void HandlePromptResponse(int selection)
    {
        switch(selection){
            case 1:
                {
                    if (UseOption1GameState)
                        ScriptEngine.Instance.SetState(Option1GameState);

                        MessageDisplayScript.ShowMessage(Option1Response, true);
                    
                    break;
                }
            case 2:
                {
                    if (UseOption2GameState)
                        ScriptEngine.Instance.SetState(Option2GameState);

                    MessageDisplayScript.ShowMessage(Option2Response, true);
                    
                    break;
                }
        }
    }
    
}
