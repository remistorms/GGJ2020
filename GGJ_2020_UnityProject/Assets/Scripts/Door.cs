using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable, IToggleable
{
    public bool isLocked;
    public Door linkedDoor;
    public Room parentRoom;
    public Transform playerSpawnPoint;

    private void Awake()
    {
        if (isLocked)
        {
            GetComponentInChildren<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            GetComponentInChildren<MeshRenderer>().material.color = Color.green;
        }
    }
    public void Interact(Interactor interactor)
    {
        if (isLocked)
        {
            Debug.Log("Door Locked");
        }
        else
        {
            ManagerRooms.instance.ChangeRooms(this, linkedDoor);
        }
    }

    private void OnDrawGizmos()
    {
        if (linkedDoor != null)
        {
            Debug.DrawLine(this.transform.position, linkedDoor.transform.position, Color.blue);
        }
   
    }

    public void Toggle()
    {
        if (isLocked)
        {
            GetComponentInChildren<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            GetComponentInChildren<MeshRenderer>().material.color = Color.red;
        }

        isLocked = !isLocked;
    }
}
