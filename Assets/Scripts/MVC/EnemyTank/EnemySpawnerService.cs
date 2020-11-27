using UnityEngine;
public class EnemySpawnerService : MonoBehaviour
{
    [SerializeField] private EnemyTankListScriptableObject enemyTankList;
    private void Start()
    {
        CreateEnemyTank();
    }

    private EnemyController CreateEnemyTank()
    {
        EnemyTankScriptableObjects enemyTankScriptableObjects = enemyTankList.enemyTanks[0];
        GameObject newGameObject = new GameObject();
        newGameObject.AddComponent<EnemyController>();
        EnemyController enemyController = newGameObject.GetComponent<EnemyController>();
        enemyController.SetEnemyController(enemyTankScriptableObjects);
        return enemyController;
    }
}
