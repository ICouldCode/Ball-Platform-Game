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
            powerUpIcon.color = new Color(255, 255, 255, 1);
            if (Input.GetKeyDown(KeyCode.V))
            {
                UsePower();
            }
        }
    }

    private void UsePower()
    {
        powerUp.UsePower(GameManager.Instance.soundEffectsSource);
        powerUpIcon.sprite = null;
        powerUpIcon.color = new Color(255, 255, 255, 0);
        powerUp = null;
    }
}
