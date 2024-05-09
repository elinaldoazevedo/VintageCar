using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractPointerUI : MonoBehaviour
{
    [SerializeField] Image _pointerFill = null;
    [SerializeField] TextMeshProUGUI _nameText = null;

    private void Awake()
    {
        ResetValues(null);
    }

    private void OnEnable()
    {
        PlayerInteractPointer.onInteractableChange += ResetValues;
    }

    private void OnDisable()
    {
        PlayerInteractPointer.onInteractableChange -= ResetValues;
    }

    private void ResetValues(InteractableElement _element)
    {
        if (_element == null)
        {
            _pointerFill.fillAmount = 0f;
            _nameText.text = null;
        }
        else
        {
            _pointerFill.fillAmount = 0f;
            _nameText.text = _element.GetDisplayName();
        }
    }
}
