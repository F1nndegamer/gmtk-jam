using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WindowSound : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private DragAndDrop dragAndDrop;
    [SerializeField] private WindowResizer windowResizer;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        dragAndDrop.OnCursorClicked += DragAndDrop_OnCursorClicked;
        dragAndDrop.OnCursorReleased += DragAndDrop_OnCursorReleased;
        windowResizer.OnCursorClicked += WindowResizer_OnCursorClicked;
        windowResizer.OnCursorReleased += WindowResizer_OnCursorReleased;
    }

    private void WindowResizer_OnCursorReleased(object sender, System.EventArgs e)
    {
        SoundManager.Instance.PlayReleaseSound();
        audioSource.Pause();
    }

    private void WindowResizer_OnCursorClicked(object sender, System.EventArgs e)
    {
        SoundManager.Instance.PlayClickSound();
        audioSource.Play();
    }

    private void DragAndDrop_OnCursorReleased(object sender, System.EventArgs e)
    {
        SoundManager.Instance.PlayReleaseSound();
        audioSource.Pause();
    }

    private void DragAndDrop_OnCursorClicked(object sender, System.EventArgs e)
    {
        SoundManager.Instance.PlayClickSound();
        audioSource.Play();
    }

}
