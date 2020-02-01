using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private int m_RoomID;
    [SerializeField] private string m_RoomName;
    [SerializeField] private Door[] m_DoorsInRoom;
}
