using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DestroyAll : MonoBehaviour
{
    List<GameObject> EnemyTankGameObject = new List<GameObject>();
    int noOfEnemyTank;
    float secToWait = 3f;
    bool isPlayerAlive = true;
    bool isGameOver = false;
    EnemySpawnerService enemySpawnerService;
    Transform currentEnemyTransform;
    ActiveEnemyController activeEnemyController;



    void Awake()
    {
        isPlayerAlive = true;
        enemySpawnerService = GameObject.FindObjectOfType<EnemySpawnerService>();
        noOfEnemyTank = enemySpawnerService.GetNoOfEnemy();
        EnemyTankGameObject = enemySpawnerService.GetEnemy();
        TankController.Instance().PlayerDeath += DestroyAllObject;
        
    }
    private void DestroyAllObject()
    {
        isPlayerAlive = false;
        TankController.Instance().gameObject.SetActive(false);
        StartCoroutine(DestroyingStarted());
    }

    IEnumerator DestroyingStarted()
    {
       for(int i= 0;i< noOfEnemyTank; i++)
       {
            if(EnemyTankGameObject[i] != null)
            {
                activeEnemyController = EnemyTankGameObject[i].GetComponent<ActiveEnemyController>();
                currentEnemyTransform = EnemyTankGameObject[i].transform;
                yield return new WaitForSeconds(secToWait);
                activeEnemyController.OnDeath();
            }
   
       }
        isGameOver = true;
    }

    public bool GetPlayerStatus()
    {
        return isPlayerAlive;
    }

    public bool GetGameStatus()
    {
        return isGameOver;
    }

    public Transform GetEnemyTankTransform()
    {
        return currentEnemyTransform;
    }
}
