using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractPointerUI : MonoBehaviour
{
    [SerializeField] PlayerSO _playerSO = null;
    [SerializeField] Image _pointerFill = null;
    [SerializeField] TextMeshProUGUI _nameText = null;
    [SerializeField] int _piecesCount = 3;

    private PlayerInteractCounter _playerInteractCounter = null;

    private void Awake()
    {
        ResetValues(null);
    }

    private void OnEnable()
    {
        PlayerInteractPointer.onInteractableChange += ResetValues;
        PlayerInteractCounter.onInteractTimeStarted += StartFill;
    }

    private void OnDisable()
    {
        PlayerInteractPointer.onInteractableChange -= ResetValues;
        PlayerInteractCounter.onInteractTimeStarted -= StartFill;
    }

    private void ResetValues(InteractableElement _element)
    {
        if (_element == null)
        {
            _pointerFill.fillAmount = 0f;
            _nameText.text = null;
        }
        else
        {
            _pointerFill.fillAmount = 0f;
            _nameText.text = _element.GetDisplayName();
        }

        StopAllCoroutines();
    }

    private void StartFill(PlayerInteractCounter _playerCounter)
    {
        _playerInteractCounter = _playerCounter;
        StartCoroutine(Fill_routine());
    }

    private IEnumerator Fill_routine()
    {
        do
        {
            _pointerFill.fillAmount += 0.34f;
            float _time = _playerSO.InteractTime / _piecesCount /** 1f*/;
            Debug.Log(Time.time);
            yield return new WaitForSeconds(_time);

        } while (_pointerFill.fillAmount < 1f);
    }
}
