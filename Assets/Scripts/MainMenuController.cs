using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Minigame");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Minigame2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Minigame3");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
