using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementAudioPlayer : MonoBehaviour
{
    [SerializeField] InteractableElement _interactableElement = null;
    [SerializeField] AudioClip _clip = null;

    private void OnEnable()
    {
        //PlayerInteractCounter.onInteractTimeEnd += TryPlayAudio;
        _interactableElement.onInteracted += Play;
    }

    private void OnDisable()
    {
        //PlayerInteractCounter.onInteractTimeEnd -= TryPlayAudio;
        _interactableElement.onInteracted -= Play;
    }

    //private void TryPlayAudio(InteractableElement _element)
    //{
    //    if (_element.gameObject == gameObject)
    //    {
    //        Play();
    //    }
    //}

    public void Play()
    {
        AudioHandler.Instance.PlayElementAudio(_clip);
    }
}
