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
        _interactableElement.onInteracted += Play;
    }

    private void OnDisable()
    {
        _interactableElement.onInteracted -= Play;
    }

    public void Play()
    {
        AudioHandler.Instance.PlayAudioDescription(_interactableElement.GetDescriptionModel());
        //AudioHandler.Instance.PlayAudioDescription(_interactableElement.So.AudioDescriptionClip);
    }
}
