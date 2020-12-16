using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public Rigidbody shellRDBD;
    public Transform aimTransform;
    public float fireForce;
    private bool isFired;

    
    private void OnTriggerEnter(Collider collision)
    {
        IDamageable damageControl = collision.gameObject.GetComponent<IDamageable>();
       
        if (damageControl != null)
        {
            damageControl.TakeDamage(25);
        }
    }
    private void Update()
    {
        if (isFired)
        {
            FireBullet();
            isFired = false;
        }
    }

    public void MakeFireTrue()
    {
        isFired = true;
    }

    private void FireBullet()
    {
        Rigidbody shellInstance = Instantiate(shellRDBD, aimTransform.position, aimTransform.rotation) as Rigidbody;
        shellInstance.velocity = fireForce * aimTransform.forward;
    }
}