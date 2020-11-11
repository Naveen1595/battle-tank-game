/*using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;*/
using UnityEngine;

public class TankService : MonoBehaviour
{
    [SerializeField] private TankView tankView;
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
        TankModel tankModel = new TankModel(5f, 100f);
        TankController tank = TankController.Instance();
        tank.SetModelView(tankModel, tankView);
        return tank;
    }
}
