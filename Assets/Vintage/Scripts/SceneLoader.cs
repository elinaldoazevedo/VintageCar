using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] string _loadScene = null;
    [SerializeField] string _unloadScene = null;
    [SerializeField] bool _loadOnStart = false;

    public static event System.Action<string, string> OnLoad = null;

    private IEnumerator Start()
    {
        yield return null;

        if (_loadOnStart)
        {
            Load();
        }
    }

    public void Load()
    {
        if (OnLoad != null)
        {
            OnLoad.Invoke(_loadScene, _unloadScene);
        }
    }
}
