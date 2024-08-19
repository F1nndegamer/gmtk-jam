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
    }

    public void RessetButton()
    {
        PersistentManagement.Instance.LoadLevel(LevelInstance.Instance.levelInstanceID + 1);
    }
}
