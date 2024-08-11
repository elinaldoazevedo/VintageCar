using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneHandler : MonoBehaviour
{
    [SerializeField] string _loadScene = null;
    //[SerializeField] string _unloadScene = null;

    public static event System.Action OnStartLoad = null;
    public static event System.Action OnEndLoad = null;

    private void OnEnable()
    {
        SceneLoader.OnLoad += SceneLoader_OnLoad;
    }

    private void OnDisable()
    {
        SceneLoader.OnLoad -= SceneLoader_OnLoad;
    }

    private void SceneLoader_OnLoad(string _loadScene, string _unloadScene)
    {
        StartCoroutine(Load_routine(_loadScene, _unloadScene));
    }

    private IEnumerator Load_routine(string _loadScene, string _unloadScene)
    {
        if (OnStartLoad != null)
            OnStartLoad.Invoke();

        if (!string.IsNullOrEmpty(_unloadScene))
        {
            var _asyncUnload = SceneManager.UnloadSceneAsync(_unloadScene);

            while (!_asyncUnload.isDone)
            {
                yield return null;
            }
        }

        var _asyncLoad = SceneManager.LoadSceneAsync(_loadScene, LoadSceneMode.Additive);

        while (!_asyncLoad.isDone)
        {
            yield return null;
        }

        if (OnEndLoad != null)
            OnEndLoad.Invoke();
    }

    public void LoadScene()
    {
        //Debug.Log("// Start Load");
        //SceneManager.LoadSceneAsync(_loadScene);
        //Debug.Log("// End Load");
        StartCoroutine(Load_routine());
    }

    private IEnumerator Load_routine()
    {
        if (OnStartLoad != null)
            OnStartLoad.Invoke();

        //if (!string.IsNullOrEmpty(_unloadScene))
        //{
        //    var _asyncUnload = SceneManager.UnloadSceneAsync(_unloadScene);

        //    while (!_asyncUnload.isDone)
        //    {
        //        yield return null;
        //    }

        //    Debug.Log("// Scene Unloaded");
        //}

        var _asyncLoad = SceneManager.LoadSceneAsync(_loadScene/*, LoadSceneMode.Additive*/);

        while (!_asyncLoad.isDone)
        {
            yield return null;
        }

        if (OnEndLoad != null)
            OnEndLoad.Invoke();
    }
}
