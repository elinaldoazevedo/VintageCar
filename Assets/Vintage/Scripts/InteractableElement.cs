using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableElement : MonoBehaviour
{
    [SerializeField] InteractableElementSO _so = null;

    public InteractableElementSO So { get { return _so; } private set { _so = value; } }

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

    public string GetDescription()
    {
        return _so.GetDescription();
    }
}
