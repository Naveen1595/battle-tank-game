using UnityEngine;

public class TankService : MonoBehaviour
{
    [SerializeField] private TankView tankView;
    //[SerializeField] private TankScriptableObjectList tankList;
    [SerializeField] private TankScriptableObject tankObj;
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
        /*TankScriptableObject tankScriptableObject = tankList.tanks[0];*/
        TankModel tankModel = new TankModel(tankObj);
        TankController tankController = TankController.Instance();
        tankController.SetModelView(tankModel, tankView);
        return tankController;
    }
}
