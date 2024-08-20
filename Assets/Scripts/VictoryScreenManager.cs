using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreenManager : MonoBehaviour
{
    Animator animator;
    bool visible;

    private void Start()
    {
        LevelManagement.Instance.OnVictory += ShowVictoryScreen;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (visible && Input.anyKeyDown && !Input.GetKeyDown(KeyCode.R))
        {
            PersistentManagement.Instance.LoadLevel(PersistentManagement.Instance.currentLevel + 1);
            visible = false;
        }
    }

    void ShowVictoryScreen()
    {
        animator.SetBool("On", true);
        visible = true;
    }

    public void Exit()
    {
        SceneManager.LoadScene(1);
    }
}
