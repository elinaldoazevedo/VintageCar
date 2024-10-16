using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnterButtonHelper : MonoBehaviour
{
    [SerializeField] NavMeshAgent _agent = null;
    [SerializeField] float _moveSpeed = 2f;

    public void Init()
    {
        _agent.speed = _moveSpeed;
    }
}
