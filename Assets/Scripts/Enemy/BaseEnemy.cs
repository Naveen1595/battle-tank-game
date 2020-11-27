using UnityEngine;
using UnityEngine.UI;

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] private Slider enemyHealthSlider;
    [SerializeField] private Image enemyfillImageSlider;
    [SerializeField] private Color enemyHealthZeroColor;
    [SerializeField] private Color enemyHealthMaxColor;
    private Rigidbody enemyrb3dTank;
    private Transform enemyTankTransform;
    private TankType enemyTankType;
    private float enemyCurrentHealth;
    [SerializeField] private float enemyTankHealth;
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
        if (enemyCurrentHealth <= 0f /*&& !_isEnemyDead*/)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        _isEnemyDead = true;
        Vector3 newPos = new Vector3(Random.Range(-4f, -20f), 0f, Random.Range(0.4f, 5f));
        enemyTankTransform.position = newPos;
        enemyCurrentHealth = enemyTankHealth;
        SetEnemyHealthUI();
    }
}