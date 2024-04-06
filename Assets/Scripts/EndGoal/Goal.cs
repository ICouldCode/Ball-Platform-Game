using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject LevelCompletePanel, PlayerUI;
    [SerializeField] private GameObject Player;

    private bool finishedLevel = false;

    private void Update()
    {
        if (finishedLevel)
        {
            Vector3 relativePos = (transform.position + new Vector3(0, 2.5f, 0)) - Player.transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);

            Quaternion current = Player.transform.localRotation;

            Player.transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
            Player.transform.Translate(0, 0, .5f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        LevelCompletePanel.SetActive(true);
        PlayerUI.SetActive(false);

        Player.GetComponent<BallMove>().canMove = false;
        Player.GetComponent<Rigidbody>().useGravity = false;
        Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        finishedLevel = true;
    }
}
