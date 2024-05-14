using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : Singleton<AudioHandler>
{
    [SerializeField] AudioSource _elementAudioSource = null;

    public void PlayElementAudio(AudioClip _audioClip)
    {
        _elementAudioSource.Stop();
        _elementAudioSource.clip = _audioClip;
        _elementAudioSource.Play();
    }
}
