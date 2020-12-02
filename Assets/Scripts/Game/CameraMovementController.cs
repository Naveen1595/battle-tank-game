using System;
using System.Collections;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    bool isEnemySpawned = false;
    private float secForWait = 2f;
    [SerializeField] private Transform playerTankTransform;
    private GameObject[] enemyTank;
    Camera cam;
    Vector3 enemyPosition;

    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();
        EnemySpawnerService.camZoomOut += EnemySpawned;
    }
    private void Start()
    {
        enemyTank = GameObject.FindGameObjectsWithTag("EnemyTank");
    }

    private void FixedUpdate()
    {
        CameraPosition();
    }

    private void EnemySpawned()
    {
        isEnemySpawned = true;
    }


    private void CameraPosition()
    {
        if (!isEnemySpawned)
        {
            cam.orthographicSize = 40f;
            gameObject.transform.position = playerTankTransform.position;
        }
        else
        {
            cam.orthographicSize = 60f;
            StartCoroutine(ZoomOutTimer(secForWait));
        }
    }

    IEnumerator ZoomOutTimer(float secForWait)
    {
        yield return new WaitForSeconds(secForWait);
        isEnemySpawned = false;
    }

}
