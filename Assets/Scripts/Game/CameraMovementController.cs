using System;
using System.Collections;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    bool isEnemySpawned = false;
    [SerializeField] private Transform playerTankTransform;
    private GameObject[] enemyTank;
    Vector3 enemyPosition;

    private void Awake()
    {
        EnemyController.camMov += camMovement;
    }
    private void Start()
    {
        enemyTank = GameObject.FindGameObjectsWithTag("EnemyTank");
    }

    private void FixedUpdate()
    {
        CameraPosition();
    }

    private void camMovement()
    {
        enemyPosition = new Vector3(enemyTank[0].transform.position.x, gameObject.transform.position.y, enemyTank[0].transform.position.z);
        isEnemySpawned = true;
    }


    private void CameraPosition()
    {
        if (!isEnemySpawned)
        {
            gameObject.transform.position = playerTankTransform.position; 
        }
        else
        {
            StartCoroutine(WaitAtPosition());
        }
    }

    IEnumerator WaitAtPosition()
    {
        gameObject.transform.position = Vector3.Lerp(playerTankTransform.position, enemyPosition, 1f);
        yield return new WaitForSeconds(2f);
        isEnemySpawned = false;
    }

}
