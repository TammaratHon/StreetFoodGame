using System;

public interface ISceneService
{
    /// <summary>
    /// Load additive scene by name. Optionally takes a callback for when loading is complete.
    /// </summary>
    void LoadSceneAdditive(string sceneName, Action onComplete = null);
    /// <summary>
    /// Unloads a scene by name. Optionally takes a callback for when unloading is complete.
    /// </summary>
    void UnloadScene(string sceneName, Action onComplete = null);
}