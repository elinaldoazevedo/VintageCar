using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableElement : MonoBehaviour
{
    [SerializeField] InteractableElementSO _so = null;

    public event System.Action onInteracted = null;

    public void Interact()
    {
        if (onInteracted != null)
            onInteracted.Invoke();
    }

    public string GetDisplayName()
    {
        return _so.GetDisplayName();
    }

    public AudioDescriptionModel GetDescriptionModel()
    {
        return _so.AudioDescriptionModel;
    }
}
