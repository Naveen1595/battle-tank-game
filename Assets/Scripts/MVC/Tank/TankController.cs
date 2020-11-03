using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoSingletonGeneric<TankController>
{
    public TankController(TankModel tankModel, TankView tankView)
    {
        TankNewModel = tankModel;
        TankNewView = GameObject.Instantiate<TankView>(tankView);
    }

    public TankModel TankNewModel { get; private set; }
    public TankView TankNewView { get; private set; }

}
