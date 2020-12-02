using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public Rigidbody shellRDBD;
    public Transform aimTransform;
    public float fireForce;
    private bool isFired;

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