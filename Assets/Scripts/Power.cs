using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/CreatePowerUp")]
public class Power : ScriptableObject
{
    public GameObject Player;
    public Sprite powerUpIcon;
    public string powerUpName;
    
    public void UsePower()
    {
        Debug.Log("Power Used");
    }
}
