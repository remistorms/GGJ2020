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
        m_PreviousRoom = currentDoor.parentRoom;
        m_CurrentRoom = nextDoor.parentRoom;
        m_CurrentRoom.gameObject.SetActive(true);
        yield return null;
        //TODO Fade transitions to hide tricks
        FindObjectOfType<Player>().transform.position = nextDoor.playerSpawnPoint.position;

        m_PreviousRoom.gameObject.SetActive(false);
    }

    private void Start()
    {
        foreach (var room in AllRooms)
        {
            room.gameObject.SetActive(false);
        }
        m_CurrentRoom.gameObject.SetActive(true);
    }
}
