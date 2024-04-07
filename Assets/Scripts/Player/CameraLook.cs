using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform ball;
    public Vector3 Offset;

    [HideInInspector] public enum Cur
    {
        PAUSED, PLAY
    }

    [HideInInspector] public Cur curs;

    private void Awake()
    {
        curs = Cur.PLAY;
    }

    private void Update()
    {
        transform.position = ball.position + Offset;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(curs == Cur.PLAY)
            {
                ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                curs = Cur.PAUSED;
            }
            else
            {
                curs = Cur.PLAY;
            }
        }

        if (curs == Cur.PLAY) { UnityEngine.Cursor.lockState = CursorLockMode.Locked; }
        else { UnityEngine.Cursor.lockState = CursorLockMode.None; }
    }

    public void LevelBeat()
    {
        curs = Cur.PAUSED;
    }
}
