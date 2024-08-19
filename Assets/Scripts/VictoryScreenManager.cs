using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScreenManager : MonoBehaviour
{
    Animator animator;
    [SerializeField]private VictoryPoint VictoryPoint;
    private void Start()
    {
        VictoryPoint.OnVictory += ShowVictoryScreen;
        animator = GetComponent<Animator>();
    }

    void ShowVictoryScreen()
    {
        animator.SetBool("On", true);
    }
}
