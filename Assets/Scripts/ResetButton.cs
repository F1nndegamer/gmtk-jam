using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RessetButton();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ReturnToMenu();
        }
    }

    public void RessetButton()
    {
        PersistentManagement.Instance.LoadLevel(LevelInstance.Instance.levelInstanceID + 1);
    }

    public void ReturnToMenu()
    {
        PersistentManagement.Instance.LoadScene(1);
    }
}
