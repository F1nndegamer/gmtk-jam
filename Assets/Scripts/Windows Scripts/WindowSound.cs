using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WindowSound : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private WindowBehavior windowBehavior;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        windowBehavior.OnCursorClicked += WindowBehavior_OnCursorClicked;
        windowBehavior.OnCursorReleased += WindowBehavior_OnCursorReleased;
    }

    private void WindowBehavior_OnCursorReleased(object sender, System.EventArgs e)
    {
        SoundManager.Instance.PlayReleaseSound();
        audioSource.Pause();
    }

    private void WindowBehavior_OnCursorClicked(object sender, System.EventArgs e)
    {
        SoundManager.Instance.PlayClickSound();
        audioSource.Play();
    }
}
