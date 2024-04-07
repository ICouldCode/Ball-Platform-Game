using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelBeat : MonoBehaviour
{
    [SerializeField] private GameObject NextLevel, PreviouseLevel;

    private void Update()
    {
        if (!SceneManager.GetActiveScene().name.Equals("Level3"))
        {
            NextLevel.SetActive(true);
        }
        else
        {
            NextLevel.SetActive(false);
        }
        if (!SceneManager.GetActiveScene().name.Equals("Level1"))
        {
            PreviouseLevel.SetActive(true);
        }
        else
        {
            PreviouseLevel.SetActive(!false);
        }
    }

    public void NextLeve()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PreviousLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
