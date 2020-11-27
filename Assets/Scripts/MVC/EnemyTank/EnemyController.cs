using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public static event Action camMov;

    [SerializeField] private Slider enemyHealthSlider;
    [SerializeField] private Image enemyfillImageSlider;
    private Color enemyHealthZeroColor;
    private Color enemyHealthMaxColor;
    private Rigidbody enemyrb3dTank;
    private Transform enemyTankTransform;
    private TankType enemyTankType;
    private float enemyCurrentHealth;
    [SerializeField] private ParticleSystem enemyTankExplosionEffect;
    [SerializeField]private float enemyTankHealth;
    [SerializeField] private float enemyTankSpeed;
    [SerializeField] private float damageValue;
    private bool _isEnemyDead;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ShellExplosion>() != null)
        {
            TakeDamage(damageValue);
        }
    }

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
    }

    private void Start()
    {
        enemyrb3dTank = gameObject.GetComponent<Rigidbody>();
        enemyTankTransform = gameObject.GetComponent<Transform>();
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

    private void OnDeath()
    {
        ExplosionEffect();
        _isEnemyDead = true;
        EnemyTankSpawningPosition();

        enemyCurrentHealth = enemyTankHealth;
        SetEnemyHealthUI();
        StartCoroutine(WaitForExplosion());
    }

    void ExplosionEffect()
    {
        enemyTankExplosionEffect.transform.parent = null;
        enemyTankExplosionEffect.transform.position = enemyTankTransform.position;
        enemyTankExplosionEffect.Play();
    }

    void EnemyTankSpawningPosition()
    {
        Vector3 newPos = new Vector3(UnityEngine.Random.Range(-30f, 35f), enemyTankTransform.position.y, UnityEngine.Random.Range(-15f, 35f));
        enemyTankTransform.position = newPos;
    }
  IEnumerator WaitForExplosion()
  { 
        yield return new WaitForSeconds(1.5f);
        camMov.Invoke();
  }
}
