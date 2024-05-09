using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableElement : MonoBehaviour
{
    [SerializeField] InteractableElementSO _so = null;

    public string GetDisplayName()
    {
        return _so.GetDisplayName();
    }

    public string GetDescription()
    {
        return _so.GetDescription();
    }
}
