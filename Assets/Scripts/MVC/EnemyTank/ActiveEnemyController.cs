using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ActiveEnemyController : MonoBehaviour,IDamageable
{

    [SerializeField] private Slider enemyHealthSlider;
    [SerializeField] private Image enemyfillImageSlider;
    private Color enemyHealthZeroColor;
    private Color enemyHealthMaxColor;
    private Rigidbody enemyrb3dTank;
    private Transform enemyTankTransform;
    private TankType enemyTankType;
    private float enemyCurrentHealth;
    [SerializeField] private ParticleSystem enemyTankExplosionEffect;
    [SerializeField] private float enemyTankHealth;
    [SerializeField] private float enemyTankSpeed;
    [SerializeField] private float damageValue;
    private bool _isEnemyDead;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<TankController>() !=null)
        {
            OnDeath();
        }
    }
    private void Awake()
    {
        enemyHealthZeroColor = Color.red;
        enemyHealthMaxColor = Color.green;
        enemyrb3dTank = gameObject.GetComponent<Rigidbody>();
        enemyTankTransform = gameObject.GetComponent<Transform>();
    }

    private void Start()
    {
        enemyCurrentHealth = enemyTankHealth;
        _isEnemyDead = false;
        SetEnemyHealthUI();
    }


    public void SetEnemyController(EnemyTankScriptableObjects enemyTankScriptableObjects)
    {
        enemyTankType = enemyTankScriptableObjects.tankType;
        enemyTankSpeed = enemyTankScriptableObjects.speed;
        enemyTankHealth = enemyTankScriptableObjects.health;
    }
    
    public void SetEnemyHealthUI()
    {
        enemyHealthSlider.value = enemyCurrentHealth;
        enemyfillImageSlider.color = Color.Lerp(enemyHealthZeroColor, enemyHealthMaxColor, enemyCurrentHealth / enemyTankHealth);
    }

    public void TakeDamage(float damage)
    {
        enemyCurrentHealth -= damage;
        SetEnemyHealthUI();
        if (enemyCurrentHealth <= 0f)
        {
            OnDeath();
        }
    }

    public void OnDeath()
    {
        ExplosionEffect();
        _isEnemyDead = true;
        enemyDies();
    }

    void ExplosionEffect()
    {
        enemyTankExplosionEffect.transform.parent = null;
        enemyTankExplosionEffect.transform.position = enemyTankTransform.position;
        enemyTankExplosionEffect.Play();
        
    }

    private void enemyDies()
    {
        Destroy(gameObject);
    }


}
