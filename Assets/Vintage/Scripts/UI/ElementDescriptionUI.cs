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
        //PlayerInteractPointer.onInteractableChange += Hide;
        //PlayerInteractCounter.onInteractTimeEnd += Show;
        AudioHandler.onAudioDescriptionPlay += Show;
        AudioHandler.onAudioDescriptionEnd += Hide;
    }

    private void OnDisable()
    {
        //PlayerInteractPointer.onInteractableChange -= Hide;
        //PlayerInteractCounter.onInteractTimeEnd -= Show;
        AudioHandler.onAudioDescriptionPlay -= Show;
        AudioHandler.onAudioDescriptionEnd -= Hide;
    }

    //private void Hide(InteractableElement _element)
    //{
    //    Hide();
    //}

    //private void Show(InteractableElement _element)
    //{
    //    _canvasGroup.alpha = 1;
    //    _text.text = _element.GetDescription();
    //}

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
