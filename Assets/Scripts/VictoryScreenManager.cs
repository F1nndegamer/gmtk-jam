using UnityEngine;

public class VictoryScreenManager : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        LevelManagement.Instance.OnVictory += ShowVictoryScreen;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.anyKey)
        {

        }
    }
    void ShowVictoryScreen()
    {
        animator.SetBool("On", true);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
