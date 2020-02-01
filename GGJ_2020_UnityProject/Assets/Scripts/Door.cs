using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public bool isLocked;
    public Door linkedDoor;
    public Room parentRoom;
    public Transform playerSpawnPoint;

    public void Interact(Interactor interactor)
    {
        if (isLocked)
        {
            Debug.Log("Door Locked");
        }
        else
        {
            RoomManager.instance.ChangeRooms(this, linkedDoor);
        }
    }
}
