using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableElement : MonoBehaviour
{
    [SerializeField] string _displayName = null;

    public string GetDisplayName()
    {
        return _displayName;
    }
}
