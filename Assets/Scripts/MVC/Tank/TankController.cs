/*using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;*/
using System;
using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoSingletonGeneric<TankController>
{
    public Slider playerHealthSlider;
    public Image fillImageSlider;
    private Color playerHealthZeroColor;
    private Color playerHealthMaxColor;
    private float playerCurrentHealth;
    private float playerFullHealth;
    private bool _isPlayerDead;
    /*public GameObject playerTankExplosion;*/
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

    private void Awake()
    {
        playerFullHealth = 100f;
        playerHealthZeroColor = Color.red;
        playerHealthMaxColor = Color.green;
    }
    private void OnEnable()
    {
        playerCurrentHealth = playerFullHealth;
        _isPlayerDead = false;

        SetHealthUI();
    }

   
    public void TakeDamage(float damage)
    {
        playerCurrentHealth -= damage;

        SetHealthUI();
        if(playerCurrentHealth <= 0f && !_isPlayerDead)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        _isPlayerDead = true;

        gameObject.SetActive(false);
    }

    private void SetHealthUI()
    {
        playerHealthSlider.value = playerCurrentHealth;
        fillImageSlider.color = Color.Lerp(playerHealthZeroColor, playerHealthMaxColor, playerCurrentHealth / playerFullHealth);
    }

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