/*using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;*/
using UnityEngine;

public class TankModel
{
    private float playerTankSpeed;
    private float playerTankHealth;
    public TankModel(float speed, float health)
    {
        playerTankSpeed = speed;
        playerTankHealth = health;  
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
