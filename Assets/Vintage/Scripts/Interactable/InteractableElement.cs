using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableElement : MonoBehaviour
{
    [SerializeField] protected InteractableElementSO _so = null;

    public event System.Action OnInteracted = null;

    public virtual void Interact()
    {
        if (OnInteracted != null)
            OnInteracted.Invoke();
    }

    public virtual string GetDisplayName()
    {
        return _so.GetDisplayName();
    }

    public virtual AudioDescriptionModel GetDescriptionModel()
    {
        return _so.AudioDescriptionModel;
    }
}
