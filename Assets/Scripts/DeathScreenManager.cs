using UnityEngine;

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
}
