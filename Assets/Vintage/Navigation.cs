using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    public Transform chegada;
    private UnityEngine.AI.NavMeshAgent auxPos;

    void Start()
    {
        auxPos = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        auxPos.destination = chegada.position;
    }

    //void Update()
    //{
    //    auxPos.destination = ene2.position;
    //}
}
