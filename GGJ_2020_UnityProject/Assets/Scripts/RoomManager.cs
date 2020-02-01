using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager instance;
    [SerializeField] private Room[] AllRooms;
    [SerializeField] private Room m_CurrentRoom;
    [SerializeField] private Room m_PreviousRoom;
    [SerializeField] private Room m_NextRoom;

    private void Awake()
    {
        instance = this;
    }

    public void ChangeRooms(Door currentDoor, Door nextDoor)
    {
        StartCoroutine(_ChangeRooms(currentDoor, nextDoor));
    }

    IEnumerator _ChangeRooms(Door currentDoor, Door nextDoor)
    {
        yield return null;
        //TODO Fade transitions to hide tricks
        FindObjectOfType<Player>().transform.position = nextDoor.playerSpawnPoint.position;
    }
}
