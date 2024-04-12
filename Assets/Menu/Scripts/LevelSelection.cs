using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    private int x = 0;

    [SerializeField] TextMeshProUGUI levelName;

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

        if(x == 0) { levelName.text = "Tutorial"; }
        else { levelName.text = "Level " + x; }
    }

    public void LeftArrow()
    {
        x--;
    }

    public void RightArrow()
    {
        x++;
    }


    public void StartLevel()
    {
        SceneManager.LoadScene(x + 1);
    }
}
