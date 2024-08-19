using UnityEngine;

public class VictoryScreenManager : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        LevelManagement.Instance.OnVictory += ShowVictoryScreen;
        animator = GetComponent<Animator>();
    }

    void ShowVictoryScreen()
    {
        animator.SetBool("On", true);
    }
}
