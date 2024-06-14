using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ElementDescriptionUI : MonoBehaviour
{
    [SerializeField] CanvasGroup _canvasGroup = null;
    [SerializeField] TextMeshProUGUI _text = null;

    private void Awake()
    {
        Hide();
    }

    private void OnEnable()
    {
        AudioHandler.onAudioDescriptionPlay += Show;
        AudioHandler.onAudioDescriptionEnd += Hide;
    }

    private void OnDisable()
    {
        AudioHandler.onAudioDescriptionPlay -= Show;
        AudioHandler.onAudioDescriptionEnd -= Hide;
    }

    private void Show(string _subtitle)
    {
        _canvasGroup.alpha = 1;
        _text.text = _subtitle;
    }

    private void Hide()
    {
        _canvasGroup.alpha = 0;
    }
}
