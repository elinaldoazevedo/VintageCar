using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadView : MonoBehaviour
{
    [SerializeField] CanvasGroup _canvasGroup = null;

    private void OnValidate()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        LoadSceneHandler.OnStartLoad += LoadSceneHandler_OnStartLoad;
        LoadSceneHandler.OnEndLoad += LoadSceneHandler_OnEndLoad;
    }

    private void OnDisable()
    {
        LoadSceneHandler.OnStartLoad -= LoadSceneHandler_OnStartLoad;
        LoadSceneHandler.OnEndLoad -= LoadSceneHandler_OnEndLoad;
    }

    private void LoadSceneHandler_OnStartLoad()
    {
        _canvasGroup.alpha = 1;
    }

    private void LoadSceneHandler_OnEndLoad()
    {
        _canvasGroup.alpha = 0;
    }
}
