/*using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;*/
using UnityEngine;

public class TankController : MonoSingletonGeneric<TankController>
{
    private Joystick joystick;
    private float tankVerticalMove, tankHorizontalMove;
    private TankModel tankNewModel;
    private TankView tankNewView;
    private Rigidbody rb3dTank;
    private Transform playerTankTransform;
    private Vector3 movement;
    private Quaternion turnRotation;

   /* public TankController(TankModel tankModel, TankView tankView)
    {
        tankNewModel = tankModel;
        tankNewView = GameObject.Instantiate<TankView>(tankView);
    }*/


    private void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        rb3dTank = gameObject.GetComponent<Rigidbody>();
        playerTankTransform = gameObject.GetComponent<Transform>();  
    }


    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Update()
    {     
        tankVerticalMove = joystick.Vertical;      
        tankHorizontalMove = joystick.Horizontal;
    }

    //To set Model and View of Tank
    public void SetModelView(TankModel tankModel, TankView tankView)
    {
        tankNewModel = tankModel;
        tankNewView = GameObject.Instantiate<TankView>(tankView);
    }

    //Forward Movement of Tank
    private void Move()
    {
        movement = tankNewModel.PlayerTankMove(tankVerticalMove, playerTankTransform);
        rb3dTank.MovePosition(rb3dTank.position + movement);
    }

    //Turn Movement of Tank
    private void Turn()
    {
        turnRotation = tankNewModel.PlayerTankTurn(tankHorizontalMove);
        rb3dTank.MoveRotation(rb3dTank.rotation * turnRotation);
    }
}