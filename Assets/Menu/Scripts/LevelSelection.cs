using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    private int x;

    void Update()
    {
        if(Input.GetButtonUp("Horizontal") && Input.GetAxis("Horizontal") > 0) { x++; }
        else if(Input.GetButtonUp("Horizontal") && Input.GetAxis("Horizontal") < 0) { x--; }

        if(x < 0) { x = 0; }
        else if(x > transform.childCount - 1) { x = transform.childCount - 1; }

        LevelSelect();

        if (Input.GetKeyDown(KeyCode.Return)) { StartLevel(); }
    }

    private void LevelSelect()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == x);
        }
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(x + 1);
    }
}
