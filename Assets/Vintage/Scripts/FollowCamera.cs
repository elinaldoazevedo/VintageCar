using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform _transform = null;
    [SerializeField] Camera _camera = null;
    [SerializeField] float _forwardMultiplier = 1f;

    private void LateUpdate()
    {
        var _cameraTransform = _camera.transform;
        _transform.position = _cameraTransform.position + _cameraTransform.forward * _forwardMultiplier;
        _transform.rotation = _cameraTransform.rotation;
    }
}
