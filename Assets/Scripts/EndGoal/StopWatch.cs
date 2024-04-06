using TMPro;
using UnityEngine;

public class StopWatch : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timer;

    private void Update()
    {
        if (!gameObject.GetComponent<Goal>().finishedLevel)
        {
            timer += Time.deltaTime;
            timerText.text = timer.ToString("0.00");
        }
    }
}
