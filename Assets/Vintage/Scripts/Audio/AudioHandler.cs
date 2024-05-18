using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : Singleton<AudioHandler>
{
    [SerializeField] AudioSource _elementAudioSource = null;

    private AudioClip _currentAudioDescriptionClip = null;

    public static event System.Action onAudioDescriptionStart = null;
    public static event System.Action onAudioDescriptionEnd = null;

    private void OnEnable()
    {
        PlayerInteractPointer.onInteractableChange += StopAudioDescription;
    }

    private void OnDisable()
    {
        PlayerInteractPointer.onInteractableChange -= StopAudioDescription;
    }

    public void PlayAudioDescription(AudioClip _audioClip)
    {
        _currentAudioDescriptionClip = _audioClip;

        _elementAudioSource.Stop();
        _elementAudioSource.clip = _audioClip;
        _elementAudioSource.Play();

        StopAllCoroutines();
        StartCoroutine(AudioDescription_routine());
    }

    private IEnumerator AudioDescription_routine()
    {
        if (onAudioDescriptionStart != null)
            onAudioDescriptionStart.Invoke();

        float _time = _currentAudioDescriptionClip.length;
        yield return new WaitForSeconds(_time);

        if (onAudioDescriptionEnd != null)
            onAudioDescriptionEnd.Invoke();
    }

    private void StopAudioDescription(InteractableElement _element)
    {
        StopAudioDescription();
    }

    public void StopAudioDescription()
    {
        if (_elementAudioSource.isPlaying)
        {
            if (onAudioDescriptionEnd != null)
                onAudioDescriptionEnd.Invoke();
        }

        _elementAudioSource.Stop();
        StopAllCoroutines();
    }
}
