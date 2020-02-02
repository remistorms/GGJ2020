using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable
{

    private int currentHealt;
    [Header("Enemy Stats")]
    public bool isAlive;
    [SerializeField] private int m_Health;
    [SerializeField] private float m_TimeToStayAlert;
    [SerializeField] private float m_MoveSpeed;
    [SerializeField] private float m_RunSpeed;

    [Header("Enemy Visuals")]
    private Animator m_EnemyAnimator;
    private NavMeshAgent m_EnemyAgent;
    [SerializeField] private MeshRenderer m_EnemyMesh;
    [SerializeField] private List<Transform> m_PatrolPoints;

    //Private fields
    private Transform currentPatrolTarget;
    private int currentPatrolTargetIndex = 0;

    public GameObject loot;

    private void Awake()
    {
        ResetEnemy();
    }

    private void ResetEnemy()
    {
        isAlive = true;
        currentHealt = m_Health;
        m_EnemyAgent = GetComponent<NavMeshAgent>();
        m_EnemyAnimator = GetComponent<Animator>();
        //m_EnemyAgent.isStopped = true;
        
    }

    public List<Transform> GetPatrolPoints()
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

    private void Die()
    {
        isAlive = false;
        this.gameObject.SetActive(false);
        int randomLoot = Random.Range(1, 5);
        for (int i = 0; i < randomLoot; i++)
        {
            GameObject lootSpawned = Instantiate( loot, transform.position, Quaternion.identity) as GameObject;
            Vector3 randomPosition = new Vector3( Random.Range(-.2f, .2f), 0, Random.Range(-.2f, .2f) );
            lootSpawned.transform.position += randomPosition;
            lootSpawned.GetComponent<PickupBolts>().lootBolts = Random.Range(10, 50);
        }
        Debug.Log("Enemy was killed");
    }

    public void TakeDamage(int damage)
    {
        currentHealt -= damage;
        if (currentHealt <= 0)
        {
            currentHealt = 0;
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().TakeDamage(5);
        }
    }


    /*
    public void SetPatrolPoints(List<Transform> _patrolPoints)
    {
        m_PatrolPoints = _patrolPoints;
    }
    */

}
