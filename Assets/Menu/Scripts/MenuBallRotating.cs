using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBallRotating : MonoBehaviour
{
    Vector3 rot;

    private void Awake()
    {
        rot = Vector3.up;
    }

    private void Update()
    {
        rot.y += Time.deltaTime * 10;
        transform.rotation = Quaternion.Euler(rot);   
    }
}
