using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Element_", menuName = "SO/Interactable Element")]
public class InteractableElementSO : ScriptableObject
{
    [SerializeField] string _displayName = null;
    [SerializeField] AudioDescriptionModel _audioDescriptionModel = null;

    public AudioDescriptionModel AudioDescriptionModel { get { return _audioDescriptionModel; } set { _audioDescriptionModel = value; } }

    public string GetDisplayName()
    {
        return _displayName;
    }
}

[System.Serializable]
public class AudioDescriptionModel
{
    [SerializeField] AudioClip[] _clips = null;
    [SerializeField, TextArea(5, 99)] string[] _texts = null;

    public AudioClip[] Clips { get { return _clips; } set { _clips = value; } }
    public string[] Texts { get { return _texts; } set { _texts = value; } }
}