using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCollactable : MonoBehaviour {

    public MessageDisplayScript messageDisplayScript;
    public string pickupMessage;
    //public Sprite PickUpImage;
    public ProximityIndicator proximityIndicator;
    public GameStates.States StateTrigger;
    public bool UseStateTrigger;

    /*
    private void FixedUpdate()
    {
        if(proximityIndicator.IsTriggered && this.gameObject.activeSelf && Input.GetButton("Submit"))
        {
            GetCollectable();
        }
    }
    */

    public void GetCollectable()
    {
        //messageDisplayScript.ShowMessageForSeconds(pickupMessage, 2);
        gameObject.SetActive(false);

        if (UseStateTrigger)
            ScriptEngine.Instance.SetState(StateTrigger);
    }
   
}
