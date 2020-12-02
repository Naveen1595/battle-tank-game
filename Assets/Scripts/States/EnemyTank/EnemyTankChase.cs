using UnityEngine;
using UnityEngine.AI;

public class EnemyTankChase : EnemyTankState
{
    [SerializeField] private float chaseDistance;
    [SerializeField] private float attackDistance;
    EnemyActiveTankManager enemyActiveTankManager;
    NavMeshAgent navMeshAgent;
    Transform playerTransform;
    private void Start()
    {
        enemyActiveTankManager = EnemyActiveTankManager.Instance();
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        float dir = Vector3.Distance(playerTransform.position, gameObject.transform.position);
        if (dir <= chaseDistance && dir > attackDistance)
        {
            gameObject.transform.LookAt(playerTransform);
            navMeshAgent.SetDestination(playerTransform.position);
        }
        else if(dir <= attackDistance)
        {
            navMeshAgent.velocity = Vector3.zero;
            enemyActiveTankManager.ChangeState(enemyActiveTankManager.GetNextState());
        }
        else if(dir > chaseDistance)
        {
            navMeshAgent.velocity = Vector3.zero;
            enemyActiveTankManager.ChangeState(enemyActiveTankManager.GetPrevState());
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

}