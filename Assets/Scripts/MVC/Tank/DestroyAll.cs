using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DestroyAll : MonoBehaviour
{
    List<GameObject> EnemyTankGameObject = new List<GameObject>();
    int noOfEnemyTank;
    float secToWait = 3f;
    EnemySpawnerService enemySpawnerService;


    void Awake()
    {
        enemySpawnerService = GameObject.FindObjectOfType<EnemySpawnerService>();
        noOfEnemyTank = enemySpawnerService.GetNoOfEnemy();
        EnemyTankGameObject = enemySpawnerService.GetEnemy();
        TankController.Instance().PlayerDeath += DestroyAllObject;
       
    }
    private void DestroyAllObject()
    {
        TankController.Instance().gameObject.SetActive(false);
        StartCoroutine(DestroyingStarted());
    }

    IEnumerator DestroyingStarted()
    {
       for(int i= 0;i< noOfEnemyTank; i++)
       {
            yield return new WaitForSeconds(secToWait);
            Destroy(EnemyTankGameObject[i]);
            
       }
    }
}
