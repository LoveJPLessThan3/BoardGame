using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    private readonly ICourutineRunner _courutineRunner;

    public SceneLoader(ICourutineRunner courutineRunner) => 
        _courutineRunner = courutineRunner;

    public void Load(string newScene, Action onLoaded = null)
    {
        _courutineRunner.StartCoroutine(LoadScene(newScene, onLoaded));
    }

    private IEnumerator LoadScene(string newScene, Action onLoaded = null)
    {
        if(SceneManager.GetActiveScene().name == newScene)
        {
            onLoaded?.Invoke();

            yield break;
        }

        AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(newScene);

        while(!waitNextScene.isDone)
            yield return null;

        onLoaded?.Invoke();
    }
}