using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractCounter : MonoBehaviour
{
    [SerializeField] PlayerSO _playerSO = null;
    //[SerializeField] float _startTime = 1f;
    //[SerializeField] float _interactTime = 3f;
    [Space]
    [SerializeField] InteractableElement _interactableElement = null;
    [SerializeField] float _timer = 0f;
    [SerializeField] bool _hasStarted = false;
    [SerializeField] bool _hasEnded = false;

    public static System.Action<PlayerInteractCounter> onInteractTimeStarted = null;
    public static System.Action<PlayerInteractCounter> onInteractTimeEnd = null;

    private void OnEnable()
    {
        PlayerInteractPointer.onInteractableChange += StartCounter;
    }

    private void OnDisable()
    {
        PlayerInteractPointer.onInteractableChange -= StartCounter;
    }

    //private void Update()
    //{
    //    return;
    //    if (_interactableElement == null) return;
    //    if (_hasEnded) return;

    //    _timer += Time.deltaTime;
    //    //Debug.Log(GetNormalizedTime());

    //    if (_timer <= _playerSO.StartInteractTime) return;

    //    // onInteractionTimerStarted.
    //    if (!_hasStarted)
    //    {
    //        _hasStarted = true;

    //        if (onInteractTimeStarted != null)
    //            onInteractTimeStarted.Invoke(this);
    //    }

    //    if (_timer >= _playerSO.InteractTime)
    //    {
    //        _hasEnded = true;

    //        // onInteractionTimerEnd.
    //        if (onInteractTimeEnd != null)
    //            onInteractTimeEnd.Invoke(this);
    //    }
    //}

    private void StartCounter(InteractableElement _element)
    {
        _interactableElement = _element;
        _timer = 0;
        _hasStarted = false;
        _hasEnded = false;

        if (_element != null)
        {
            StartCoroutine(Interact_routine());
        }
    }

    private IEnumerator Interact_routine()
    {
        yield return new WaitForSeconds(_playerSO.StartInteractTime);

        if (onInteractTimeStarted != null)
            onInteractTimeStarted.Invoke(this);

        yield return new WaitForSeconds(_playerSO.InteractTime);

        if (onInteractTimeEnd != null)
            onInteractTimeEnd.Invoke(this);
    }
}
