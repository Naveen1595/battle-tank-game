using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    public Button button;
    public Rigidbody shellRDBD;
    public Transform aimTransform;
    public float fireForce;
    private bool isFired;

    private void Start()
    {
        button.onClick.AddListener(FireBulletPressed);
    }


    private void Update()
    {
        if (isFired)
        {
            FireBullet();
            isFired = false;
        }
    }

    private void FireBulletPressed()
    {
        isFired = true;
    }
    
    private void FireBullet()
    {
        Rigidbody shellInstance = Instantiate(shellRDBD, aimTransform.position, aimTransform.rotation) as Rigidbody;
        shellInstance.velocity = fireForce * aimTransform.forward;
    }
}
