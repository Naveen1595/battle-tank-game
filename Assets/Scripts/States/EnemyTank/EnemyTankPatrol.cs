using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankPatrol : EnemyTankState
{
    [SerializeField] private float chaseDistance;
    Transform playerTransform;
    int currentIndex = 0;
    NavMeshAgent navMeshAgent;
    Rigidbody enemyTankrdbd;
    EnemyActiveTankManager enemyActiveTankManager;
    [SerializeField] private List<Transform> destinationList;
    private void Start()
    {
        enemyActiveTankManager = EnemyActiveTankManager.Instance();
        enemyTankrdbd = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent.velocity = Vector3.zero;
        MoveToDestination();
    }
    private void Update()
    {
        float dir = Vector3.Distance(playerTransform.position, gameObject.transform.position);
        if(dir <= chaseDistance)
        {
            navMeshAgent.velocity = Vector3.zero;
            enemyActiveTankManager.ChangeState(enemyActiveTankManager.GetNextState());
        }
        else
        {
            LookTowardTarget();
            CheckReached();
            if (CheckReached())
            {
                navMeshAgent.velocity = Vector3.zero;
                ChangeDestination();
                MoveToDestination();
            }
        }
    }
    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    private void LookTowardTarget()
    {

        Vector3 targetDirection = destinationList[currentIndex].position - transform.position;
        Quaternion rotateTowardTarget = Quaternion.LookRotation(targetDirection);
        transform.rotation = rotateTowardTarget;
    }

    private void ChangeDestination()
    {
        if (currentIndex < (destinationList.Count - 1))
            currentIndex++;
        else
            currentIndex = 0;
    }

    private bool CheckReached()
    {
        if (navMeshAgent.remainingDistance <= 1f)
            return true;
        else
            return false;
    }

    private void MoveToDestination()
    {
        Vector3 targetPos = destinationList[currentIndex].position;
        navMeshAgent.SetDestination(targetPos);
    }
}