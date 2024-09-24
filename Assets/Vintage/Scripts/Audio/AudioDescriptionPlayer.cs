using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDescriptionPlayer : MonoBehaviour
{
    [SerializeField] InteractableElement _interactableElement = null;

    private void OnValidate()
    {
        _interactableElement = GetComponent<InteractableElement>();
    }

    private void OnEnable()
    {
        _interactableElement.OnInteracted += Play;
    }

    private void OnDisable()
    {
        _interactableElement.OnInteracted -= Play;
    }

    public void Play()
    {
        var _model = _interactableElement.GetDescriptionModel();
        AudioHandler.Instance.PlayAudioDescription(_model);
    }
}
