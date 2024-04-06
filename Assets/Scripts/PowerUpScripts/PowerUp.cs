using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]Power power;

    private void Awake()
    {
        power.Player = FindObjectOfType<PlayerPowerUp>().gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerPowerUp>().powerUp = power;
        Destroy(gameObject);
    }
}
