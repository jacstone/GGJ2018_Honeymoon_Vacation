using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTracker : MonoBehaviour {
    public List<GameObject> activeRooms = new List<GameObject>();
    public List<GameObject> allRooms;
    // Use this for initialization

    public void UpdateRoomVisibility()
    {
        DarkenDoors();
        foreach (var room in allRooms)
        {
            if (activeRooms.Contains(room))
            {
                LightRoom(room);
            } else
            {
                ActivateSubObjects(room, false);
            }
        }
    }

    internal void DarkenDoors()
    {
        var doors = GameObject.FindGameObjectsWithTag("Door");
        foreach (GameObject door in doors)
        {
            ActivateSubObjects(door, false);
        }
    }

    public void LightRoom(GameObject room)
    {
        ActivateSubObjects(room, true);

        var doors = GameObject.FindGameObjectsWithTag("Door");
        foreach(GameObject door in doors)
        {
            var doorScript = door.GetComponentInChildren<Door>();
            foreach(GameObject connectedRoom in doorScript.connectedRooms)
            {
                if (connectedRoom == room || doorScript.IsOpen)
                {
                    ActivateSubObjects(door, true);
                    break;
                }
            }
        }
    }

    private void ActivateSubObjects(GameObject item, bool active)
    {
        foreach (Transform obj in item.transform)
        {

            if (obj != item.transform)
            {
                if (!active || !obj.gameObject.CompareTag("Indicator"))
                obj.gameObject.SetActive(active);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Room"))
        {            
            activeRooms.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Room"))
        {
            activeRooms.Remove(other.gameObject);
        }
    }
}
