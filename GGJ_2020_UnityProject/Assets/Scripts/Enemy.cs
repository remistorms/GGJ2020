using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator m_EnemyAnimator;
    [SerializeField] private NavMeshAgent m_EnemyAgent;
    [SerializeField] private MeshRenderer m_EnemyMesh;
    [SerializeField] private Transform[] m_PatrolPoints;
    [SerializeField] private float m_TimeToStayAlert;
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private float m_RunSpeed;

    private Transform currentPatrolTarget;
    private int currentPatrolTargetIndex = 0;

    private void Awake()
    {
        ResetEnemy();
    }

    private void ResetEnemy()
    {
        m_EnemyAgent = GetComponent<NavMeshAgent>();
        m_EnemyAnimator = GetComponent<Animator>();
        m_EnemyAgent.isStopped = true;
        
    }

    public Transform[] GetPatrolPoints()
    {
        return m_PatrolPoints;
    }

    public void GoToNextPosition()
    {
        StartCoroutine(_GoToNextPositionRoutine());
    }

    IEnumerator _GoToNextPositionRoutine()
    {
        yield return new WaitForSeconds(1.5f);
    }

    public void ChangeColor(Color color)
    {
        m_EnemyMesh.material.color = color;
    }
}
