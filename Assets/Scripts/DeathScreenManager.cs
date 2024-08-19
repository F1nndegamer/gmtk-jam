using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        LevelManagement.Instance.OnDeath += ShowVictoryScreen;
        animator = GetComponent<Animator>();
    }

    void ShowVictoryScreen()
    {
        animator.SetBool("On", true);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Restrat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
