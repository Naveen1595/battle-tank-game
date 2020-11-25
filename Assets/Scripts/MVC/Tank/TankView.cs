using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour
{
    [SerializeField]private Slider playerHealthSlider;
    [SerializeField]private Image fillImageSlider;
    private Color playerHealthZeroColor;
    private Color playerHealthMaxColor;

    private void Awake()
    {
        playerHealthZeroColor = Color.red;
        playerHealthMaxColor = Color.green;
    }
    public void SetHealthUI()
    {
        TankController tankController = TankController.Instance();
        playerHealthSlider.value = tankController.GetCurrentHealth();
        fillImageSlider.color = Color.Lerp(playerHealthZeroColor, playerHealthMaxColor, tankController.GetCurrentHealth() / tankController.GetMaxHealth());
    }

}
