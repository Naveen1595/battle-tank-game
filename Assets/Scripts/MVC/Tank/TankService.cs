/*using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;*/
using UnityEngine;

public class TankService : MonoBehaviour
{
    [SerializeField] private TankView tankView;
    [SerializeField] private TankScriptableObjectList tankList;
    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        CreateTank();
        
    }

    private TankController CreateTank()
    {
        TankScriptableObject tankScriptableObject = tankList.tanks[2];
        TankModel tankModel = new TankModel(tankScriptableObject);
        TankController tank = TankController.Instance();
        tank.SetModelView(tankModel, tankView);
        return tank;
    }
}
