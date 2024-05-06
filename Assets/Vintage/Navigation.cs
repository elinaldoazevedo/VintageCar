using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour {

    public Transform chegada;
    private UnityEngine.AI.NavMeshAgent auxPos;

    // Use this for initialization
    void Start()
    {
        auxPos = transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
        auxPos.destination = chegada.position;
    }

    // Update is called once per frame
    void Update()
    {
        //auxPos.destination = ene2.position;
    }
}
