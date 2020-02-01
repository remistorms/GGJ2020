using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Room : MonoBehaviour
{
    [SerializeField] private int m_RoomID;
    [SerializeField] private string m_RoomName;
    [SerializeField] private Door[] m_DoorsInRoom;

    public Enemy[] m_EnemiesInRoom;
    public PatrolPoint[] m_EnemyPatrolPoints;

    private void Start()
    {
        ActivateRoom();
    }

    public void ActivateRoom()
    {
        m_EnemiesInRoom = GetComponentsInChildren<Enemy>();
        m_EnemyPatrolPoints = GetComponentsInChildren<PatrolPoint>();

        List<Transform> patrolPointsTransforms = new List<Transform>();

        for (int i = 0; i < m_EnemyPatrolPoints.Length; i++)
        {
            patrolPointsTransforms.Add(m_EnemyPatrolPoints[i].transform);
        }

        foreach (var enemy in m_EnemiesInRoom)
        {
            enemy.SetPatrolPoints(patrolPointsTransforms);

        }
    }
}
