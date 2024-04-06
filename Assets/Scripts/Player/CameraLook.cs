using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform ball;
    public Vector3 Offset;

    private enum cursor
    {
        PAUSED, PLAY
    }

    private cursor curs;

    private void Awake()
    {
        curs = cursor.PLAY;
    }

    private void Update()
    {
        transform.position = ball.position + Offset;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(curs == cursor.PLAY)
            {
                ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                curs = cursor.PAUSED;
            }
            else
            {
                curs = cursor.PLAY;
            }
        }

        if (curs == cursor.PLAY) { Cursor.lockState = CursorLockMode.Locked; }
        else { Cursor.lockState = CursorLockMode.None; }
    }
}
