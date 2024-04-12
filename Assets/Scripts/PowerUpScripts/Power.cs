using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/CreatePowerUp")]
public class Power : ScriptableObject
{
    public GameObject Player;

    public Sprite powerUpIcon;
    public string powerUpName;
    public float powerUpMultiplier;
    public AudioClip soundFX;
    
    public void UsePower(AudioSource AS)
    {

        switch (powerUpName)
        {
            case "Rocket Jump":
                Player.GetComponent<Rigidbody>().AddForce(Vector3.up * powerUpMultiplier, ForceMode.Impulse);
                break;
            case "Antigravity":
                Physics.gravity *= -1;
                if(Physics.gravity.y > 0.0f)
                {
                    Camera.main.transform.rotation = Quaternion.Euler(new Vector3(-20, 0, 180));
                    Player.GetComponent<BallMove>().gravity = BallMove.Gravity.DOWN;
                }
                else
                {
                    Camera.main.transform.rotation = Quaternion.Euler(new Vector3(20, 0, 0));
                    Player.GetComponent<BallMove>().gravity = BallMove.Gravity.UP;
                }
                Camera.main.transform.GetComponent<CameraLook>().Offset.y *= -1;
                break;
            case "SpeedBoost":
                if (Input.GetAxis("Horizontal") > 0) { Player.transform.position += new Vector3(powerUpMultiplier * Time.deltaTime, 0.1f, 0.0f); }
                else if (Input.GetAxis("Horizontal") < 0) { Player.transform.position += new Vector3(-powerUpMultiplier * Time.deltaTime, 0.1f, 0.0f); }

                if (Input.GetAxis("Vertical") > 0) { Player.transform.position += new Vector3(0.0f , 0.0f, powerUpMultiplier * Time.deltaTime); }
                else if (Input.GetAxis("Vertical") < 0) { Player.transform.position += new Vector3(0.0f, 0.0f, -powerUpMultiplier * Time.deltaTime); }

                break;
            case "MegaSphere":
                Player.GetComponent<BallMove>().AbilityDuration = powerUpMultiplier;
                Player.GetComponent<BallMove>().MaxAbilityDuration = powerUpMultiplier;
                if(Player.transform.localScale != new Vector3(5.0f, 5.0f, 5.0f))
                {
                    Player.transform.localScale *= 5f;
                } 
                break;

        }

        AS.clip = soundFX;
        AS.Play();
    }
}
