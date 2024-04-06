using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public GameObject MenuPanel, OptionsPanel;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void MapEditor()
    {

    }

    public void Settings()
    {
        OptionsPanel.SetActive(true);
        MenuPanel.SetActive(false);
    }

    public void Back()
    {
        OptionsPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
