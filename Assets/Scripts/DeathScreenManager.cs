using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenManager : MonoBehaviour
{
    Animator animator;
    [SerializeField] private Trap VictoryPoint;
    private void Start()
    {
        VictoryPoint.OnDeath += ShowVictoryScreen;
        animator = GetComponent<Animator>();
    }

    void ShowVictoryScreen()
    {
        animator.SetBool("On", true);
    }
}
