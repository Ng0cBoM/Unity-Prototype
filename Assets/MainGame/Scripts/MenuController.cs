using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
 
    public void PlayGame()
    {
        //PlayerPrefs.SetInt("HighScore", 0);
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }

    
}
