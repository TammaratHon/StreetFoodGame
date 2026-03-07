using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using StreetFoodGame.Application.Interfaces;

namespace StreetFoodGame.Infrastructure.Services
{
    public class UnitySceneService : ISceneService
    {
        public async UniTask LoadScene(string sceneName, Action onComplete = null)
        {
            await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            onComplete?.Invoke();
        }

        public async UniTask LoadSceneAdditive(string sceneName, Action onComplete = null)
        {
            await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            onComplete?.Invoke();
        }

        public async UniTask UnloadScene(string sceneName, Action onComplete = null)
        {
            if(!SceneManager.GetSceneByName(sceneName).isLoaded)
            {
                onComplete?.Invoke();
                return;
            }
            
            await SceneManager.UnloadSceneAsync(sceneName);
            onComplete?.Invoke();
        }
    }
}