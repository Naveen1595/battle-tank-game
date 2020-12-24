using System.Collections;
using UnityEngine;
public class EnemyTankState : MonoBehaviour
{
    public virtual void OnEnter()
    {
        this.enabled = true;
    }

    public virtual void OnExit()
    {
        this.enabled = false;
    }
}