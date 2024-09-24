using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractCounter : MonoBehaviour
{
    [SerializeField] PlayerSO _playerSO = null;
    [SerializeField] AudioHandler _audioHandler = null;

    private InteractableElement _interactableElement = null;
    private InteractableElement _interactablePlaying = null;

    public static System.Action onInteractTimeStarted = null;
    public static System.Action<InteractableElement> onInteractTimeEnd = null;

    private void OnEnable()
    {
        PlayerInteractPointer.OnInteractableChange += StartCounter;
        //AudioHandler.onAudioDescriptionEnd += AudioHandler_onAudioDescriptionEnd;
    }

    private void OnDisable()
    {
        PlayerInteractPointer.OnInteractableChange -= StartCounter;
        //AudioHandler.onAudioDescriptionEnd -= AudioHandler_onAudioDescriptionEnd;
    }

    private void StartCounter(InteractableElement _element)
    {
        if (_audioHandler.IsPlayingElement(_element)) return;
        //if (_element == null || _element == _interactableElement)
        //{
        //    StopAllCoroutines();
        //    return;
        //}
        //if (_audioHandler.IsPlaying()) return;
        //if (_element == null) return;
        //if (_element == _interactableElement) return;
        //if (_element == _interactablePlaying)
        //{
        //    StopAllCoroutines();
        //    return;
        //}

        _interactableElement = _element;
        StopAllCoroutines();

        if (_element != null)
        {
            StartCoroutine(Interact_routine());
        }
    }

    private IEnumerator Interact_routine()
    {
        yield return new WaitForSeconds(_playerSO.StartInteractTime);

        if (onInteractTimeStarted != null)
            onInteractTimeStarted.Invoke();

        yield return new WaitForSeconds(_playerSO.InteractTime);

        if (onInteractTimeEnd != null)
            onInteractTimeEnd.Invoke(_interactableElement);

        _interactablePlaying = _interactableElement;
        _interactableElement.Interact();
    }

    //private void AudioHandler_onAudioDescriptionEnd()
    //{
    //    _interactablePlaying = null;
    //    _interactableElement = null;
    //}
}
