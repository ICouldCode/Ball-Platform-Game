using UnityEngine;
using UnityEngine.UI;

public class PlayerPowerUp : MonoBehaviour
{
    public Image powerUpIcon;
    [HideInInspector]public Power powerUp;

    private void Update()
    {
        if( powerUp!= null)
        {
            powerUpIcon.sprite = powerUp.powerUpIcon;
            if (Input.GetKeyDown(KeyCode.V))
            {
                UsePower();
            }
        }
    }

    private void UsePower()
    {
        powerUp.UsePower();
        powerUpIcon.sprite = null;
        powerUp = null;
    }
}
