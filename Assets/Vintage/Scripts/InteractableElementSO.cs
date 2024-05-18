using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Element_", menuName = "SO/Interactable Element")]
public class InteractableElementSO : ScriptableObject
{
    [SerializeField] string _displayName = null;
    [SerializeField] AudioClip _audioDescriptionClip = null;
    [SerializeField, TextArea(5, 99)] string _description = null;

    [SerializeField] AudioClip[] _audioClips = null;
    [SerializeField, TextArea(5, 99)] string[] _descriptionTexts = null;

    public AudioClip AudioDescriptionClip { get { return _audioDescriptionClip; } private set { _audioDescriptionClip = value; } }

    public string GetDisplayName()
    {
        return _displayName;
    }

    public string GetDescription()
    {
        return _description;
    }
}

public class AudioDescriptionModel
{
    public AudioClip[] _clips = null;
    public string[] _texts = null;
}