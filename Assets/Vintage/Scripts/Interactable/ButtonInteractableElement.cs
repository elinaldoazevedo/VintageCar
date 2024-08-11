using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractableElement : InteractableElement
{
    [SerializeField] Button _button = null;

    private void OnValidate()
    {
        _button = GetComponent<Button>();
    }

    public override void Interact()
    {
        if (_button.onClick != null)
            _button.onClick.Invoke();

        base.Interact();
    }
}
