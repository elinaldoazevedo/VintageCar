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
        Hide(null);
    }

    //private void OnEnable()
    //{
    //    PlayerInteractPointer.onInteractableChange += Hide;
    //    PlayerInteractCounter.onInteractTimeEnd += Show;
    //}

    //private void OnDisable()
    //{
    //    PlayerInteractPointer.onInteractableChange -= Hide;
    //    PlayerInteractCounter.onInteractTimeEnd -= Show;
    //}

    private void Hide(InteractableElement _element)
    {
        _canvasGroup.alpha = 0;
    }

    private void Show(InteractableElement _element)
    {
        _canvasGroup.alpha = 1;
        _text.text = _element.GetDescription();
    }
}
