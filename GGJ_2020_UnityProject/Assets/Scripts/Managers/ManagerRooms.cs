using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerRooms : MonoBehaviour
{
    public static ManagerRooms instance;
    [SerializeField] private Room[] AllRooms;
    [SerializeField] private Room m_CurrentRoom;
    [SerializeField] private Room m_PreviousRoom;
    //[SerializeField] private Room m_NextRoom;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void ChangeRooms(Door currentDoor, Door nextDoor)
    {
        StartCoroutine(_ChangeRooms(currentDoor, nextDoor));
    }

    IEnumerator _ChangeRooms(Door currentDoor, Door nextDoor)
    {
        ManagerUI.instance.faderScreen.FadeOut(0.2f);
        ManagerGame.instance.GetPlayerReference().m_PlayerMovement.enabled = false;
        m_PreviousRoom = currentDoor.parentRoom;
        m_CurrentRoom = nextDoor.parentRoom;
        yield return new WaitForSeconds(0.25f);
    
        //m_CurrentRoom.gameObject.SetActive(true);
        //m_PreviousRoom.gameObject.SetActive(false);
        ManagerGame.instance.GetPlayerReference().transform.position = nextDoor.playerSpawnPoint.position;

        yield return new WaitForSeconds(0.25f);
        ManagerUI.instance.faderScreen.FadeIn(0.1f);
        ManagerUI.instance.faderScreen.FadeIn(0.1f);
        ManagerGame.instance.GetPlayerReference().m_PlayerMovement.enabled = true;

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
