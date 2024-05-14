using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractPointer : MonoBehaviour
{
    [SerializeField] Transform _origin = null;
    [SerializeField] LayerMask _layerMask = 0;
    [SerializeField] float _maxDistance = 20f;
    [SerializeField] float _radius = 1f;
    [SerializeField] QueryTriggerInteraction _queryTriggerInteraction;

    private InteractableElement _interactableElement = null;
    private RaycastHit[] _results = new RaycastHit[1];

    public static event System.Action<InteractableElement> onInteractableChange = null;

    private void Update()
    {
        var _lastInteractable = _interactableElement;
        _interactableElement = SearchForInteractable();

        if (_interactableElement != _lastInteractable)
        {
            if (onInteractableChange != null)
                onInteractableChange.Invoke(_interactableElement);
        }
    }

    private InteractableElement SearchForInteractable()
    {
        var _ray = new Ray(_origin.position, _origin.forward);
        int _hits = Physics.SphereCastNonAlloc(_ray, _radius, _results, _maxDistance, _layerMask, _queryTriggerInteraction);

        for (int i = 0; i < _hits; i++)
        {
            var _collider = _results[i].collider;
            return _collider.GetComponent<InteractableElement>();
        }

        return null;
    }
}
