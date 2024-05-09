using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Element_", menuName = "SO/Interactable Element")]
public class InteractableElementSO : ScriptableObject
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
