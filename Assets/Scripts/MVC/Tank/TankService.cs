using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    [SerializeField] TankView tankView;
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
        TankModel tankModel = new TankModel(5, 40f);
        TankController tank = new TankController(tankModel, tankView);
        return tank;
    }
}
