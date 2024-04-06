using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenu : MonoBehaviour
{
    public GameObject PauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { PauseMenu.SetActive(!PauseMenu.activeSelf); Time.timeScale = PauseMenu.activeSelf ? 0 : 1; }    
    }
}
