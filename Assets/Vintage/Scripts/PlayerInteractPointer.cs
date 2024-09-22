using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractPointer : MonoBehaviour
{
    [SerializeField] Transform _origin = null;
    //[SerializeField] Transform _pointer = null;
    //[SerializeField] GvrReticlePointer _gvrReticle = null;
    //[SerializeField] float _maxPointerDistance = 0.1f;
    [SerializeField] LayerMask _layerMask = 0;
    [SerializeField] float _maxDistance = 20f;
    [SerializeField] float _radius = 1f;
    [SerializeField] QueryTriggerInteraction _queryTriggerInteraction;

    private InteractableElement _interactableElement = null;
    private RaycastHit[] _results = new RaycastHit[1];

    public static event System.Action<InteractableElement> OnInteractableChange = null;

    private void LateUpdate()
    {
        var _lastInteractable = _interactableElement;
        _interactableElement = SearchForInteractable();

        if (_interactableElement != _lastInteractable)
        {
            if (OnInteractableChange != null)
                OnInteractableChange.Invoke(_interactableElement);
        }
    }

    private InteractableElement SearchForInteractable()
    {
        var _ray = new Ray(_origin.position, _origin.forward);
        int _hits = Physics.SphereCastNonAlloc(_ray, _radius, _results, _maxDistance, _layerMask, _queryTriggerInteraction);

        for (int i = 0; i < _hits; i++)
        {
            var _collider = _results[i].collider;
            //Fodase();

            return _collider.GetComponent<InteractableElement>();
        }

        //_pointer.position = _origin.position + _origin.forward * _maxPointerDistance;
        //Fodase();

        return null;
    }

    //public void Fodase()
    //{
    //    //var _pointHit = _results[i].point;
    //    var _pointHit = _gvrReticle._pos;
    //    var difference = _pointHit - _origin.position;
    //    var direction = difference.normalized;
    //    var distance = Mathf.Min(_maxPointerDistance, difference.magnitude);
    //    var endPosition = _origin.position + direction * distance;
    //    _pointer.position = endPosition;
    //}
}
