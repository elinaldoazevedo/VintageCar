using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player_Data", menuName = "SO/Player Data")]
public class PlayerSO : ScriptableObject
{
    [SerializeField] float _startInteractTime = 1f;
    [SerializeField] float _interactTime = 3f;

    public float StartInteractTime { get { return _startInteractTime; } private set { _startInteractTime = value; } }
    public float InteractTime { get { return _interactTime; } private set { _interactTime = value; } }
}
