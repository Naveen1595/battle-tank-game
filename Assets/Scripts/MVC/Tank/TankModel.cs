using UnityEngine;

public class TankModel
{
    private float playerTankSpeed;
    private float playerTankHealth;
    private TankType playerTankType;
    public TankModel(TankScriptableObject tankScriptableObject)
    {
        playerTankType = tankScriptableObject.tankType;
        playerTankSpeed = tankScriptableObject.speed;
        playerTankHealth = tankScriptableObject.health;  
    }

    public float GetPlayerHealth()
    {
        return playerTankHealth;
    }

    public void SetPlayerHealth(float damage)
    {
        playerTankHealth -= damage; 
    }
    public Vector3 PlayerTankMove(float playerTankVerticalMove,Transform playerTankTransform)
    {
        Vector3 movement = playerTankTransform.transform.forward * playerTankVerticalMove * playerTankSpeed * Time.deltaTime;
        return movement;
    }

    public Quaternion PlayerTankTurn(float playerTankHorizontalMove)
    {
        float turn = playerTankHorizontalMove * 100f * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        return turnRotation;
    }
}
