using System;
using System.Collections;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField] private Transform playerTankTransform;
    Camera cam;

    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        CameraPosition();
    }

    private void CameraPosition()
    {
        cam.orthographicSize = 20f;
        gameObject.transform.position = playerTankTransform.position;
    }

}
