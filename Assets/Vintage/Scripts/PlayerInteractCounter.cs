using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractCounter : MonoBehaviour
{
    [SerializeField] PlayerInteractPointer _playerInteractPointer = null;
    [SerializeField] float _startTime = 1f;
    [SerializeField] float _interactTime = 3f;
    [Space]
    [SerializeField] InteractableElement _interactableElement = null;
    [SerializeField] float _timer = 0f;

    private void OnEnable()
    {
        _playerInteractPointer.onInteractableChange += ResetTimer;
    }

    private void OnDisable()
    {
        _playerInteractPointer.onInteractableChange -= ResetTimer;
    }

    private void Update()
    {
        if (_interactableElement == null) return;

        _timer += Time.deltaTime;

        if (_timer <= _startTime) return;

        // onInteractionTimerStarted.
        
        if (_timer >= _interactTime)
        {
            // onInteractionTimerEnd.
        }
    }

    private void ResetTimer(InteractableElement _element)
    {
        _interactableElement = _element;
        _timer = 0;
    }
}
