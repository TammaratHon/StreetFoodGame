using System;
using Cysharp.Threading.Tasks;
namespace StreetFoodGame.Application.Interfaces
{
    public interface ISceneService
    {
        UniTask LoadScene(string sceneName, Action onComplete = null);
        UniTask LoadSceneAdditive(string sceneName, Action onComplete = null);
        UniTask UnloadScene(string sceneName, Action onComplete = null);
    }
}