using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public static event Action camMov;
    private Vector3 screenBound;
    [SerializeField] private Slider enemyHealthSlider;
    [SerializeField] private Image enemyfillImageSlider;
    [SerializeField] private Color enemyHealthZeroColor;
    [SerializeField] private Color enemyHealthMaxColor;
    [SerializeField] private ParticleSystem enemyTankExplosionEffect;
    private Rigidbody enemyrb3dTank;
    private Transform enemyTankTransform;
    private TankType enemyTankType;
    private float enemyCurrentHealth;
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
        enemyHealthMaxColor = Color.cyan;

    }

    private void Start()
    {
        enemyrb3dTank = gameObject.GetComponent<Rigidbody>();
        enemyTankTransform = gameObject.GetComponent<Transform>();
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Camera.main.transform.position.y,Screen.height));
       /* Debug.Log(" x- " + screenBound.x + " y- " + screenBound.y + " z- " + screenBound.z);*/
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
        if (enemyCurrentHealth <= 0f /*&& !_isEnemyDead*/)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        enemyTankExplosionEffect.transform.parent = null;
        enemyTankExplosionEffect.Play();
        _isEnemyDead = true;
        Vector3 newPos = new Vector3(UnityEngine.Random.Range(0f, screenBound.x), 0f, UnityEngine.Random.Range(0f, screenBound.z));
        //Vector3 newPos = new Vector3(41f, 0f, 42f);
        enemyTankTransform.position = newPos;
        enemyCurrentHealth = enemyTankHealth;
        SetEnemyHealthUI();
        camMov.Invoke();
    }
}
