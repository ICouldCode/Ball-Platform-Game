using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    //Menu
    public GameObject MenuPanel, OptionsPanel, LevelPick;

    //Settings
    public GameObject Game, Graphics, Audio, Acces;

    public void Play()
    {
        LevelPick.SetActive(true);
        MenuPanel.SetActive(false);
    }

    public void MapEditor()
    {
        SceneManager.LoadScene(4);
    }

    public void Settings()
    {
        OptionsPanel.SetActive(true);
        MenuPanel.SetActive(false);
    }
    public void MenuBack()
    {
        OptionsPanel.SetActive(false);
        LevelPick.SetActive(false);
        MenuPanel.SetActive(true);
    }

    public void GameSubPanel()
    {
        Game.SetActive(true);
        Graphics.SetActive(false);
        Audio.SetActive(false);
        Acces.SetActive(false);
    }

    public void AudioSubPanel()
    {
        Game.SetActive(false);
        Graphics.SetActive(false);
        Audio.SetActive(true);
        Acces.SetActive(false);
    }

    public void GraphicsSubPanel()
    {
        Game.SetActive(false);
        Graphics.SetActive(true);
        Audio.SetActive(false);
        Acces.SetActive(false);
    }

    public void AccesibilitySubPanel()
    {
        Game.SetActive(false);
        Graphics.SetActive(false);
        Audio.SetActive(false);
        Acces.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
