using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDescriptionPlayer : MonoBehaviour
{
    [SerializeField] InteractableElement _interactableElement = null;
    [SerializeField] AudioClip _clip = null;

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
        AudioHandler.Instance.PlayAudioDescription(_clip);
    }
}
