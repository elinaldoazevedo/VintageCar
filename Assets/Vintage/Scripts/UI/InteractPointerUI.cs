using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractPointerUI : MonoBehaviour
{
    [SerializeField] PlayerSO _playerSO = null;
    [SerializeField] CanvasGroup _canvasGroup = null;
    [SerializeField] Image _pointerFill = null;
    [SerializeField] TextMeshProUGUI _nameText = null;
    [SerializeField] int _piecesCount = 3;

    private void Awake()
    {
        ResetValues(null);
    }

    private void OnEnable()
    {
        PlayerInteractPointer.OnInteractableChange += ResetValues;
        PlayerInteractCounter.onInteractTimeStarted += StartFill;
        AudioHandler.onAudioDescriptionStart += AudioHandler_onAudioDescriptionStart;
    }

    private void OnDisable()
    {
        PlayerInteractPointer.OnInteractableChange -= ResetValues;
        PlayerInteractCounter.onInteractTimeStarted -= StartFill;
        AudioHandler.onAudioDescriptionStart -= AudioHandler_onAudioDescriptionStart;
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

        Show();
        StopAllCoroutines();
    }

    private void StartFill()
    {
        StartCoroutine(Fill_routine());
    }

    private IEnumerator Fill_routine()
    {
        do
        {
            _pointerFill.fillAmount += 0.34f;
            float _time = _playerSO.InteractTime / (_piecesCount - 1);
            yield return new WaitForSeconds(_time);

        } while (_pointerFill.fillAmount < 1f);
    }

    private void AudioHandler_onAudioDescriptionStart()
    {
        Hide();
    }

    private void Show()
    {
        _canvasGroup.alpha = 1;
    }

    private void Hide()
    {
        _canvasGroup.alpha = 0;
    }
}
