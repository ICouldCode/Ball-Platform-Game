using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    [SerializeField]private GameObject PauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { PauseMenu.SetActive(!PauseMenu.activeSelf); Time.timeScale = PauseMenu.activeSelf ? 0 : 1; }    
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
