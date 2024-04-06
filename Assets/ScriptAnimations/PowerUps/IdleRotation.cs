using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleRotation : MonoBehaviour
{
    Vector3 rot;

    private void Awake()
    {
        rot = Vector3.up;
    }

    void Update()
    {
        rot.y += (Time.deltaTime * 100);
        transform.rotation = Quaternion.Euler(rot);
    }
}
