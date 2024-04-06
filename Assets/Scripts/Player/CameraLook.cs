using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform ball;
    public Vector3 Offset;

    private void Update()
    {
        transform.position = ball.position + Offset; 
    }
}
