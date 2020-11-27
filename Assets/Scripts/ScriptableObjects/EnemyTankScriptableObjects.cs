using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTankScriptableObjects", menuName = "EnemyTankScriptableObjects")]
public class EnemyTankScriptableObjects : ScriptableObject
{
    public TankType tankType;
    public string tankName;
    public float speed;
    public float health;
}

[CreateAssetMenu(fileName = "EnemyTankScriptableObjects", menuName = "EnemyTankScriptableObjectsList")]

public class EnemyTankListScriptableObject : ScriptableObject
{
    public EnemyTankScriptableObjects[] enemyTanks;
}
