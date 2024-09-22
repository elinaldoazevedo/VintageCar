using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform _transform = null;
    [SerializeField] Camera _camera = null;
    [SerializeField] float _forwardMultiplier = 1f;
    [SerializeField] LayerMask _layerMask = 0;

    [SerializeField] float _minDistance = 0.5f;
    [SerializeField] float _maxDistance = 1f;
    [SerializeField] float _radius = 0.1f;
    [SerializeField] QueryTriggerInteraction _queryTriggerInteraction;

    public Vector3 _point;
    private RaycastHit[] _results = new RaycastHit[1];

    private void LateUpdate()
    {
        //var _cameraTransform = _camera.transform;
        //_transform.position = _cameraTransform.position + _cameraTransform.forward * _forwardMultiplier;
        //_transform.rotation = _cameraTransform.rotation;

        SearchForInteractable();
        return;
        var _pointHit = SearchForInteractable();
        var difference = _pointHit - _camera.transform.position;
        var direction = difference.normalized;
        var distance = Mathf.Min(0.5f, difference.magnitude);
        var endPosition = _camera.transform.position + direction * distance;
        _transform.position = endPosition;
        _transform.rotation = _camera.transform.rotation;

    }

    private Vector3 SearchForInteractable()
    {
        var _ray = new Ray(_camera.transform.position, _camera.transform.forward);
        int _hits = Physics.RaycastNonAlloc(_ray, _results, _maxDistance, _layerMask, _queryTriggerInteraction);
        //int _hits = Physics.SphereCastNonAlloc(_ray, _radius, _results, _maxDistance, _layerMask, _queryTriggerInteraction);

        for (int i = 0; i < _hits; i++)
        {
            var _collider = _results[i].collider;

            var _pointHit = _results[i].point;
            var difference = _pointHit - _camera.transform.position;
            var direction = difference.normalized;
            var distance = Mathf.Min(_minDistance, difference.magnitude);
            var endPosition = _camera.transform.position + direction * distance;

            _transform.position = _pointHit + -_camera.transform.forward * 0.01f;
            _transform.rotation = _camera.transform.rotation;
            _point = _pointHit;
            Debug.Log(_collider.name);
            return Vector3.zero;
        }

        _transform.position = _camera.transform.position + _camera.transform.forward * _minDistance;
        _transform.rotation = _camera.transform.rotation;
        return Vector3.zero;
        //return _camera.transform.position + _camera.transform.forward * _maxDistance;
    }

    //public void Fodase()
    //{
    //    var _pointHit = _results[i].point;
    //    var difference = _pointHit - _camera.transform.position;
    //    var direction = difference.normalized;
    //    var distance = Mathf.Min(0.5f, difference.magnitude);
    //    var endPosition = _camera.transform.position + direction * distance;
    //    _transform.position = endPosition;
    //}
}
