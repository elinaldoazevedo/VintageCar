using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioDescriptionUI : MonoBehaviour
{
    [SerializeField] Image _image = null;

    private void Awake()
    {
        Hide();
    }

    private void OnEnable()
    {
        AudioHandler.onAudioDescriptionStart += Show;
        AudioHandler.onAudioDescriptionEnd += Hide;
    }

    private void OnDisable()
    {
        AudioHandler.onAudioDescriptionStart += Show;
        AudioHandler.onAudioDescriptionEnd += Hide;
    }

    private void Show()
    {
        _image.enabled = true;
    }

    private void Hide()
    {
        _image.enabled = false;
    }
}
