using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public ProximityIndicator proximityIndicator;
    public bool IsOpen = false;
    public bool CanInteract = true;
    public RoomTracker roomTracker;
    public GameObject[] connectedRooms;

    private void FixedUpdate()
    {
        if (proximityIndicator.IsTriggered && CanInteract && Input.GetButton("Submit"))
        {
            StartCoroutine(OpenDoor());
        }
    }

    public IEnumerator OpenDoor()
    {
        roomTracker.DarkenDoors();
        foreach(var room in connectedRooms)
        {
            roomTracker.LightRoom(room);
        }
        CanInteract = false;
        Quaternion origRotation = transform.localRotation;
        float elapsedTime = 0.0f;
        float rotationTime = .75f;
        Vector3 startingPosition = transform.localPosition;

        Quaternion targetRotation = Quaternion.Euler(0.0f, IsOpen ? 0f : -90f, 0f);

        while (elapsedTime < rotationTime)
        {            
            // Rotations
            transform.localRotation = Quaternion.Slerp(origRotation, targetRotation, (elapsedTime / rotationTime));

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.localRotation = targetRotation;
        Debug.Log("Translation and rotation done! ");
        CanInteract = true;
        IsOpen = !IsOpen;

        if (IsOpen == false)
            roomTracker.UpdateRoomVisibility();
        
        yield return 0;
    }
}
