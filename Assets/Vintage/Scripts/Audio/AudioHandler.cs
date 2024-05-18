using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : Singleton<AudioHandler>
{
    [SerializeField] AudioSource _elementAudioSource = null;
    [SerializeField] float _timeBetweenClips = 0.1f;

    public static event System.Action onAudioDescriptionStart = null;
    public static event System.Action<string> onAudioDescriptionPlay = null;
    public static event System.Action onAudioDescriptionEnd = null;

    private void OnEnable()
    {
        PlayerInteractPointer.onInteractableChange += StopAudioDescription;
    }

    private void OnDisable()
    {
        PlayerInteractPointer.onInteractableChange -= StopAudioDescription;
    }

    public void PlayAudioDescription(AudioDescriptionModel _model)
    {
        StopAllCoroutines();
        StartCoroutine(AudioDescription_routine(_model));
    }

    private IEnumerator AudioDescription_routine(AudioDescriptionModel _model)
    {
        if (onAudioDescriptionStart != null)
            onAudioDescriptionStart.Invoke();

        int _count = _model.Clips.Length;

        for (int i = 0; i < _count; i++)
        {
            var _clip = _model.Clips[i];

            _elementAudioSource.Stop();
            _elementAudioSource.clip = _clip;
            _elementAudioSource.Play();

            var _subtitle = _model.Texts[i];

            if (onAudioDescriptionPlay != null)
                onAudioDescriptionPlay.Invoke(_subtitle);

            var _time = _clip.length + _timeBetweenClips;
            yield return new WaitForSeconds(_time);
        }

        if (onAudioDescriptionEnd != null)
            onAudioDescriptionEnd.Invoke();
    }

    private void StopAudioDescription(InteractableElement _element)
    {
        StopAudioDescription();
    }

    public void StopAudioDescription()
    {
        if (!_elementAudioSource.isPlaying) return;

        if (onAudioDescriptionEnd != null)
            onAudioDescriptionEnd.Invoke();

        _elementAudioSource.Stop();
        StopAllCoroutines();
    }
}
