using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float enemyTankSpeed;
    private float enemyTankHealth;
    private TankType enemyTankType;
    public EnemyController(TankScriptableObject tankScriptableObject)
    {
        enemyTankType = tankScriptableObject.tankType;
        enemyTankSpeed = tankScriptableObject.speed;
        enemyTankHealth = tankScriptableObject.health;
    }

    /*public Vector3 PlayerTankMove(float playerTankVerticalMove, Transform playerTankTransform)
    {
        Vector3 movement = playerTankTransform.transform.forward * playerTankVerticalMove * enemyTankSpeed * Time.deltaTime;
        return movement;
    }

    public Quaternion PlayerTankTurn(float playerTankHorizontalMove)
    {
        float turn = playerTankHorizontalMove * 100f * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        return turnRotation;
    }*/
}
