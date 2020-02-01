using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : StateMachineBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    private Transform currentPatrolTarget;
    public float distanceFromCurrentTarget;
    public int currentPatrolTargetIndex;
    private NavMeshAgent navMeshAgent;
    private Enemy enemy;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Enemy>();
        navMeshAgent = animator.GetComponent<NavMeshAgent>();
        patrolPoints = enemy.GetPatrolPoints();

        currentPatrolTarget = patrolPoints[0];
        navMeshAgent.SetDestination(currentPatrolTarget.position);
        navMeshAgent.isStopped = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Patrol State Update : " + patrolPoints.Length + " patrol points found");

        distanceFromCurrentTarget = Vector3.Distance( animator.transform.position, currentPatrolTarget.position);

        if (distanceFromCurrentTarget <= 0.1f)
        {
            GetNextPosition();       
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    private void GetNextPosition()
    {
        currentPatrolTargetIndex++;

        if (currentPatrolTargetIndex >= patrolPoints.Length)
        {
            currentPatrolTargetIndex = 0;
        }

        currentPatrolTarget = patrolPoints[currentPatrolTargetIndex];

        navMeshAgent.SetDestination(currentPatrolTarget.position);
        navMeshAgent.isStopped = false;
    }

}
