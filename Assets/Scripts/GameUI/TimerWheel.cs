using UnityEngine;
using UnityEngine.UI;

public class TimerWheel : MonoBehaviour
{
    private BallMove Player;
    [SerializeField] Image timeWheel;
    [SerializeField] GameObject wholeWheel;

    private void Awake()
    {
        Player = FindObjectOfType<BallMove>();
    }

    private void Update()
    {
        wholeWheel.gameObject.SetActive(Player.AbilityDuration > 0 ? true : false);
        timeWheel.fillAmount = (Player.AbilityDuration / Player.MaxAbilityDuration);
    }
}
