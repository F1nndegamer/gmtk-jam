using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    private const string IS_JUMPING = "IsJumping";
    [SerializeField] private PlayerMovement playerMovement;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        animator.SetBool(IS_WALKING, playerMovement.IsWalking());
        animator.SetBool(IS_JUMPING, playerMovement.IsJumping());
    }
}
