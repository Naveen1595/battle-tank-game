using System;
using UnityEngine;
public class EnemySpawnerService : MonoBehaviour
{
    public static event Action camZoomOut;
    [SerializeField] private int noOfSpawnIdelTank;
    [SerializeField] private int noOfSpawnActiveTank;
    [SerializeField] private GameObject idelEnemyTank;
    [SerializeField] private Transform idelEnemyTankTrans;
    [SerializeField] private GameObject activeEnemyTank;
    [SerializeField] private Transform activeEnemyTankTrans;

    private void Start()
    {
        SpawnEnemyTanks(noOfSpawnIdelTank);
        SpawnEnemyActiveTanks(noOfSpawnActiveTank);
        camZoomOut.Invoke();
    }

    //Spawn Active Enemy Tank
    private void SpawnEnemyActiveTanks(int noOfSpawnActiveTank)
    {
        for (int i = 0; i < noOfSpawnActiveTank; i++)
        {
            CreteEnemyActiveTanks();
        }
    }

    //Create Idle Enemy Tank
    private GameObject CreteEnemyActiveTanks()
    {
        return Instantiate(activeEnemyTank, activeEnemyTankTrans.position, Quaternion.identity) as GameObject;
    }

    //Spawn Idle Enemy Tank
    private void SpawnEnemyTanks(int noOfSpawnTank)
    {
        for(int i=0;i< noOfSpawnTank;i++)
        {
            CreteEnemyTanks(NewPositionCreator());
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
        return new Vector3(UnityEngine.Random.Range(-30f, 35f), idelEnemyTankTrans.position.y, UnityEngine.Random.Range(-15f, 35f));
    }

}
