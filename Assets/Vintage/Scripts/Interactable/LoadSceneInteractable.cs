using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneInteractable : InteractableElement
{
    public override void Interact()
    {
        Debug.Log("// LoadSceneInteractable");
        base.Interact();
    }
}
