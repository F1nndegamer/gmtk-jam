using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private float footstepTimer;
    private float footstepTimerMax = 0.15f;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        footstepTimer -= Time.deltaTime;
        if (footstepTimer <= 0f)
        {
            footstepTimer = footstepTimerMax;
            if (playerMovement.IsWalking())
            {
                SoundManager.Instance.PlayFootStepSound(transform.position);
            }
        }
    }
}
