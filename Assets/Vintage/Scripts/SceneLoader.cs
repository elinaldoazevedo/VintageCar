﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] string _loadScene = null;
    [SerializeField] string _unloadScene = null;
    [SerializeField] bool _loadOnStart = false;
    [SerializeField] bool _loadAsync = true;

    public static event System.Action<string> OnLoad = null;
    public static event System.Action<string, string> OnLoadAsync = null;

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
        if (_loadAsync)
        {
            if (OnLoadAsync != null)
                OnLoadAsync.Invoke(_loadScene, _unloadScene);
        }
        else
        {
            if (OnLoad != null)
                OnLoad.Invoke(_loadScene);
        }
    }
}
