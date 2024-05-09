using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableElement : MonoBehaviour
{
    [SerializeField] string _displayName = null;
    [SerializeField, TextArea(5, 99)] string _description = null;

    public string GetDisplayName()
    {
        return _displayName;
    }

    public string GetDescription()
    {
        return _description;
    }
}
