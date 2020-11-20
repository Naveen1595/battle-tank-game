using System;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    public Button button;
    public Rigidbody shellRDBD;
    public Transform aimTransform;
    public float fireForce;

    private string fireButton;
    private bool isFired;

    private void Awake()
    {
        button.onClick.AddListener(MakeFireBulletTrue);
    }


    private void Start()
    {
        fireButton = "Fire";
    }

    private void Update()
    {
        if (isFired)
        {
            FireBullet();
            isFired = false;
        }
    }

    private void MakeFireBulletTrue()
    {
        isFired = true;
    }
    
    private void FireBullet()
    {
        Rigidbody shellInstance = Instantiate(shellRDBD, aimTransform.position, aimTransform.rotation) as Rigidbody;
        shellInstance.velocity = fireForce * aimTransform.forward;
    }
}
