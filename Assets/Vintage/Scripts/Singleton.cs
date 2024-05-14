using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] bool _isPersistent = false;

    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<T>();

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
        }
        else if (_instance != this as T)
        {
            Destroy(gameObject);
            return;
        }

        if (_isPersistent)
        {
            DontDestroyOnLoad(_instance);
        }
    }

    private void OnDestroy()
    {
        if (_isPersistent == false)
        {
            _instance = null;
        }
    }
}
