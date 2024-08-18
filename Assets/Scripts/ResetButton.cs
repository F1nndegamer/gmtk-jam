using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void RessetButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
