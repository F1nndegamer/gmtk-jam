using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;
    [SerializeField] private float volume = 1;
    private void Awake()
    {
        Instance = this;
    }
    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        PlaySound(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume);
    }
    private void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume * volumeMultiplier);
    }
    public void PlayClickSound()
    {
        PlaySound(audioClipRefsSO.windowClick, Vector3.zero);
    }
    public void PlayReleaseSound()
    {
        PlaySound(audioClipRefsSO.windowRelease, Vector3.zero);
    }
    public void PlayFootStepSound(Vector2 footstepPosition)
    {
        PlaySound(audioClipRefsSO.footstep, footstepPosition);
    }
}
