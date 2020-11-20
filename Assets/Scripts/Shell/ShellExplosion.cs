using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public LayerMask tankMask;
    public ParticleSystem ExplosionParticles;
    public float maxDamage;
    public float explosionForce;
    public float explosionRadius;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, tankMask);

        for(int i=0;i<colliders.Length;i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
            if (!targetRigidbody)
                continue;

            targetRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);

            TankController tank = TankController.Instance();
            tank.TakeDamage(maxDamage);

            ExplosionParticles.transform.parent = null;
            Destroy(ExplosionParticles.gameObject, ExplosionParticles.duration);
            Destroy(gameObject);
        }
    }
}
