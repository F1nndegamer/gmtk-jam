using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Simple class containing methods that buttons can call. Called UIFunctions because functions sound better than methods.
/// </summary>
public class UIFunctions : MonoBehaviour
{
    public void LoadScene(string sceneID)
    {
        PersistentManagement.Instance.LoadScene(sceneID);
    }

    public void PauseTheGame()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }
}
