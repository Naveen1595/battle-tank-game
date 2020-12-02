using UnityEngine;
using UnityEngine.AI;

public class EnemyTankAttack : EnemyTankState
{
    float shootTime = 0f, totalTime = 30f;
    [SerializeField] private float attackDistance;
    [SerializeField] private float chaseDistance;
    Transform playerTransform;
    NavMeshAgent navMeshAgent;
    EnemyBulletController enemyBulletController;
    EnemyActiveTankManager enemyActiveTankManager;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyBulletController = GetComponent<EnemyBulletController>();
        enemyActiveTankManager = EnemyActiveTankManager.Instance();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        float dir = Vector3.Distance(playerTransform.position, gameObject.transform.position);
        if (dir <= attackDistance)
        {
            navMeshAgent.velocity = Vector3.zero;
            gameObject.transform.LookAt(playerTransform);
            if(shootTime <= totalTime)
            {
                shootTime++;
            }
            else
            {
                shootTime = 0;
                enemyBulletController.MakeFireTrue();
            }

            
        }
        else if(dir <= chaseDistance && dir > attackDistance)
        {
            navMeshAgent.velocity = Vector3.zero;
            enemyActiveTankManager.ChangeState(enemyActiveTankManager.GetPrevState());
        }
        else
        {
            navMeshAgent.velocity = Vector3.zero;
            enemyActiveTankManager.ChangeState(enemyActiveTankManager.GetNextState());
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