using System.Collections;
using UnityEngine;

 public class DestroyAllScene : MonoSingletonGeneric<DestroyAllScene>
 {
    [SerializeField] GameObject completeLevelArt;
    [SerializeField] GameObject playerTank;
    [SerializeField] GameObject enemyTank;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject playerTankView;
    /*[SerializeField] GameObject
    [SerializeField] GameObject
    [SerializeField] GameObject */

    public void DestroyScene()
    {
        Destroy(completeLevelArt);
       
        Destroy(enemyTank);
        Destroy(playerTankView);
        Destroy(playerTank);
        Destroy(gameObject);
        //Destroy();
    }
}