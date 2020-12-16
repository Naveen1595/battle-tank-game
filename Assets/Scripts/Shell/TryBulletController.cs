using UnityEngine;
using System;
public class TryBulletController : MonoBehaviour
{
    float damageValue = 20;
  private void OnTriggerEnter(Collider other)
  {
        IDamageable damageControl = other.gameObject.GetComponent<IDamageable>();
        if(damageControl != null)
        {
            damageControl.TakeDamage(damageValue);
        }
  }
}
