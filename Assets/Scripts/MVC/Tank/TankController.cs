using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankController : MonoSingletonGeneric<TankController>
{
    private TankModel tankNewModel;
    private TankView tankNewView;
    private Rigidbody rb3dTank;
    private Joystick joystick;
    [SerializeField] private ParticleSystem tankExplosionEffect;
    private float playerCurrentHealth;
    private bool _isPlayerDead;
    private float tankVerticalMove, tankHorizontalMove;
    private Vector3 movement;
    private Quaternion turnRotation;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<ActiveEnemyController>() !=null)
        {
            OnDeath();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<ShellExplosion>() != null)
        {
            TakeDamage(25);
        }
    }
    private void Start()
    {
        joystick = GameObject.FindObjectOfType<Joystick>();
        rb3dTank = gameObject.GetComponent<Rigidbody>();
        _isPlayerDead = false;
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Update()
    {
        /*tankVerticalMove = joystick.Vertical;
        tankHorizontalMove = joystick.Horizontal;*/
        tankHorizontalMove = Input.GetAxisRaw("Horizontal1");
        tankVerticalMove = Input.GetAxisRaw("Vertical1");
    }

    //To set Model and View of Tank
    public void SetModelView(TankModel tankModel, TankView tankView)
    {
        tankNewModel = tankModel;
        tankNewView = GameObject.Instantiate<TankView>(tankView);
        playerCurrentHealth = tankNewModel.GetPlayerHealth();
        tankNewView.SetHealthUI();
    }

    //Forward Movement of Tank
    private void Move()
    {
        movement = tankNewModel.PlayerTankMove(tankVerticalMove, gameObject.transform);
        rb3dTank.MovePosition(rb3dTank.position + movement);
    }

    //Turn Movement of Tank
    private void Turn()
    {
        turnRotation = tankNewModel.PlayerTankTurn(tankHorizontalMove);
        rb3dTank.MoveRotation(rb3dTank.rotation * turnRotation);
    }

    public void TakeDamage(float damage)
    {
        playerCurrentHealth -= damage;
        tankNewView.SetHealthUI();
        if(playerCurrentHealth <= 0f && !_isPlayerDead)
        {
            OnDeath();
        }
    }

    public float GetCurrentHealth()
    {
        return playerCurrentHealth;
    }

    public float GetMaxHealth()
    {
        return tankNewModel.GetPlayerHealth();
    }

    private void OnDeath()
    {
        tankExplosionEffect.transform.parent = null;
        tankExplosionEffect.Play();
        _isPlayerDead = true;
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

}