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
        ManagerGame.instance.GetPlayerReference().m_PlayerMovement.enabled = false;
        ManagerUI.instance.faderScreen.FadeOut(0.2f);

        yield return new WaitForSeconds(.2f);
        //Room stuff
        m_CurrentRoom = nextDoor.parentRoom;
        currentDoor.parentRoom.HideRoom();
        nextDoor.parentRoom.UnhideRoom();
        //Player and camera positioning
        Vector3 newPosition = currentDoor.linkedDoor.playerSpawnPoint.position;

        ManagerGame.instance.GetPlayerReference().transform.position = newPosition;
        ManagerGame.instance.cameraRig.transform.position = newPosition;
        //Fade In
        ManagerUI.instance.faderScreen.FadeIn(0.2f);

        yield return new WaitForSeconds(0.2f);

        ManagerGame.instance.GetPlayerReference().m_PlayerMovement.enabled = true;

    }

    private void Start()
    {
        //Get All Rooms
        AllRooms = FindObjectsOfType<Room>();

        /*
        for (int i = 0; i < AllRooms.Length; i++)
        {
            AllRooms[i].transform.position = new Vector3(0, 100 * i, 0);
            AllRooms[i].HideRoom();
        }

        m_CurrentRoom.UnhideRoom();

        */

        Transform spawnPoint = GameObject.FindWithTag("Respawn").transform;
        ManagerGame.instance.GetPlayerReference().transform.position = spawnPoint.position;
    }
}
