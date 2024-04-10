using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject LevelCompletePanel, PlayerUI;
    [SerializeField] private GameObject Player;
    [SerializeField] TMPro.TextMeshProUGUI time;
    [SerializeField] private Transform rotateTarget;

    [HideInInspector]public bool finishedLevel = false;

    private void Update()
    {
        if (finishedLevel)
        {
            Camera.main.GetComponent<CameraLook>().LevelBeat();
            Player.transform.RotateAround(rotateTarget.position, Vector3.up, 90 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        LevelCompletePanel.SetActive(true);
        time.text = gameObject.GetComponent<StopWatch>().timerText.text;
        PlayerUI.SetActive(false);

        if (Player.transform.localScale != Vector3.one)
        {
            Player.transform.localScale = Vector3.one;
            Player.transform.localPosition = (Player.transform.localPosition - rotateTarget.localPosition) + Vector3.up * 2;
        }
        Player.transform.position += Vector3.up;
        Player.GetComponent<BallMove>().canMove = false;
        Player.GetComponent<Rigidbody>().useGravity = false;
        Player.GetComponent<Rigidbody>().isKinematic = true;
        finishedLevel = true;
    }
}
