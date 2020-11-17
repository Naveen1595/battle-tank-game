using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTankScriptableObjects", menuName = "EnemyTankScriptableObjects")]
public class EnemyTankScriptableObjects : ScriptableObject
{
    public TankType tankType;
    public string tankName;
    public float speed;
    public float health;
    /*public BulletType bullet;
    public TankView tankView;*/
}

[CreateAssetMenu(fileName = "EnemyTankScriptableObjects", menuName = "EnemyTankScriptableObjectsList")]

public class EnemyTankListScriptableObject : ScriptableObject
{
    EnemyTankScriptableObjects[] enemyTanks;
}
