using System;
using System.Collections;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField] private Transform playerTankTransform;
    Camera cam;
    float transitionSpeed = 2;
    Transform nextLocation;
    [SerializeField] DestroyAll destroyAll;
    
    bool isPlayerAlive = true;

    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();
        //destroyAll = GetComponent<DestroyAll>();

    }

    private void FixedUpdate()
    {
        CameraPosition();
    }

    private void CameraPosition()
    {
        isPlayerAlive = destroyAll.GetPlayerStatus();
        if (isPlayerAlive)
        {
            cam.orthographicSize = 20f;
            transform.position = playerTankTransform.position;
        }
        else if(!destroyAll.GetGameStatus() && !isPlayerAlive)
        {
            nextLocation = destroyAll.GetEnemyTankTransform();
            transform.position = Vector3.Lerp(transform.position, nextLocation.position, Time.deltaTime * transitionSpeed);
        }
        else
        {
            transform.position = new Vector3(0f, 0f, 0f);
        }
        
    }

}
