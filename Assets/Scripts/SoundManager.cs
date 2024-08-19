using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;
    [SerializeField] private float volume = 1f;
    public bool turning;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        PlaySound(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume);
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1f)
    {
        AudioSource audioSource = new GameObject("Sound").AddComponent<AudioSource>();
        audioSource.transform.position = position;
        audioSource.clip = audioClip;
        audioSource.volume = volume * volumeMultiplier;
        audioSource.Play();

        // Start the StopSoundWhenDone coroutine only for the rotating sound
        if (audioClip == audioClipRefsSO.Rotating)
        {
            StartCoroutine(StopSoundWhenDone(audioSource));
            Debug.Log("rotating");
        }
        else
        {
            Destroy(audioSource.gameObject, audioClip.length);
        }
    }

    private IEnumerator StopSoundWhenDone(AudioSource audioSource)
    {
        // Wait until the 'turning' is false
        while (turning)
        {
            yield return null;
            Debug.Log("stop");
            audioSource.Stop();
            Destroy(audioSource.gameObject);
        }
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

    public void PlaySpikeDeath()
    {
        PlaySound(audioClipRefsSO.SpikeDeath, Vector3.zero);
    }

    public void PlayTurnStart(Transform rotatepos)
    {
        PlaySound(audioClipRefsSO.SpinStart, rotatepos.position);
    }

    public void PlayTurning(Transform rotatepos)
    {
        PlaySound(audioClipRefsSO.Rotating, rotatepos.position);
    }
}
