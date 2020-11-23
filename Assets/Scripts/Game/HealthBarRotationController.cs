using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarRotationController : MonoBehaviour
{
    private Quaternion tankRotation;
    private void Start()
    {
        tankRotation = transform.parent.localRotation;
    }

    private void Update()
    {
        transform.rotation = tankRotation;
    }
}
