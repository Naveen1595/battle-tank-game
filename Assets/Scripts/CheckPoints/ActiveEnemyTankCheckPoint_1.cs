using System.Collections;
using UnityEngine;
public class ActiveEnemyTankCheckPoint_1 : MonoBehaviour
{
    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}