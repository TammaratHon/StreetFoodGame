using System;
using UnityEngine.SceneManagement;

public class SceneService : ISceneService
{
    public async void LoadSceneAdditive(string sceneName, Action onComplete = null)
    {
        var operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!operation.isDone)
        {
            await System.Threading.Tasks.Task.Yield();
        }
        onComplete?.Invoke();
    }

    public async void UnloadScene(string sceneName, Action onComplete = null)
    {
        var operation = SceneManager.UnloadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            await System.Threading.Tasks.Task.Yield();
        }
        onComplete?.Invoke();
    }
}