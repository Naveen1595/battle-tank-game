using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public ParticleSystem shellExplosionEffect;   
    private void OnTriggerEnter(Collider other)
    {
        shellExplosionEffect.transform.parent = null;
        shellExplosionEffect.Play();
        gameObject.SetActive(false); 
    }

}
