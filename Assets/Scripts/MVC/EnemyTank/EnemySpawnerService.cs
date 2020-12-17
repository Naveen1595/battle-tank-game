using System.Collections.Generic;
using UnityEngine;
public class EnemySpawnerService : MonoBehaviour
{
    [SerializeField] private int noOfSpawnIdelTank;
    [SerializeField] private int noOfSpawnActiveTank;
    [SerializeField] private GameObject idelEnemyTank;
    [SerializeField] private GameObject activeEnemyTank;
    List<GameObject> listOfEnemyGameObjects = new List<GameObject>();
    private void Start()
    {
        
        SpawnEnemyTanks(noOfSpawnIdelTank);
        SpawnEnemyActiveTanks(noOfSpawnActiveTank);
    }

    //Spawn Active Enemy Tank
    private void SpawnEnemyActiveTanks(int noOfSpawnActiveTank)
    {
        for (int i = 0; i < noOfSpawnActiveTank; i++)
        {
            GameObject activeEnemyGameObject = CreteEnemyActiveTanks(NewPositionCreator());
            listOfEnemyGameObjects.Add(activeEnemyGameObject);
        }
    }

    //Create Idle Enemy Tank
    private GameObject CreteEnemyActiveTanks(Vector3 tankTrans)
    {
        return Instantiate(activeEnemyTank, tankTrans, Quaternion.identity) as GameObject;
    }

    //Spawn Idle Enemy Tank
    private void SpawnEnemyTanks(int noOfSpawnTank)
    {
        for(int i=0;i< noOfSpawnTank;i++)
        {
            GameObject idleEnemyGameObject = CreteEnemyTanks(NewPositionCreator());
            listOfEnemyGameObjects.Add(idleEnemyGameObject);
        }
    }

    //Create Idle Enemy Tank
    private GameObject CreteEnemyTanks(Vector3 tankTrans)
    {
        return Instantiate(idelEnemyTank, tankTrans, Quaternion.identity) as GameObject;
    }

    //Random Position
    private Vector3 NewPositionCreator()
    {
        return new Vector3(UnityEngine.Random.Range(-30f, 35f), idelEnemyTank.transform.position.y, UnityEngine.Random.Range(-15f, 35f));
    }


    public int GetNoOfEnemy()
    {
        return (noOfSpawnIdelTank + noOfSpawnActiveTank);
    }

    public List<GameObject> GetEnemy()
    {
        return listOfEnemyGameObjects;
    }


}
