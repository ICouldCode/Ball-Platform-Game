using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public AudioSource soundEffectsSource;

    private void Awake()
    {
        Instance = this;
    }
}
